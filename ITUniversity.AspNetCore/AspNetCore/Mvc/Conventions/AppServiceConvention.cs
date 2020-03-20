using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using ITUniversity.Application.Services;
using ITUniversity.Extensions;
using ITUniversity.Reflection;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;

namespace ITUniversity.AspNetCore.Mvc.Conventions
{
    public class AppServiceConvention : IApplicationModelConvention
    {
        private readonly IServiceCollection services;

        public AppServiceConvention(IServiceCollection services)
        {
            this.services = services;
        }

        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                var type = controller.ControllerType.AsType();

                if (typeof(IApplicationService).GetTypeInfo().IsAssignableFrom(type))
                {
                    controller.ControllerName = controller.ControllerName.RemovePostFix(ApplicationService.CommonPostfixes);
                    //ConfigureArea(controller, "task");
                    ConfigureRemoteService(controller);
                }
            }
        }

        //private void ConfigureArea(ControllerModel controller, string area)
        //{
        //    if (string.IsNullOrWhiteSpace(area))
        //    {
        //        return;
        //    }

        //    if (controller.RouteValues.ContainsKey("area"))
        //    {
        //        return;
        //    }

        //    controller.RouteValues["area"] = area;
        //}

        private void ConfigureRemoteService(ControllerModel controller)
        {
            ConfigureApiExplorer(controller);
            ConfigureSelector(controller);
            ConfigureParameters(controller);
        }

        private void ConfigureSelector(ControllerModel controller)
        {
            RemoveEmptySelectors(controller.Selectors);

            if (controller.Selectors.Any(selector => selector.AttributeRouteModel != null))
            {
                return;
            }

            //var moduleName = "task";

            foreach (var action in controller.Actions)
            {
                ConfigureSelector(/*moduleName, */controller.ControllerName, action);
            }
        }

        private void ConfigureSelector(/*string moduleName, */string controllerName, ActionModel action)
        {
            RemoveEmptySelectors(action.Selectors);

            if (!action.Selectors.Any())
            {
                AddAbpServiceSelector(/*moduleName, */controllerName, action);
            }
            else
            {
                NormalizeSelectorRoutes(/*moduleName, */controllerName, action);
            }
        }

        private static void NormalizeSelectorRoutes(/*string moduleName, */string controllerName, ActionModel action)
        {
            foreach (var selector in action.Selectors)
            {
                if (selector.AttributeRouteModel == null)
                {
                    selector.AttributeRouteModel = CreateAbpServiceAttributeRouteModel(
                        //moduleName,
                        controllerName,
                        action
                    );
                }
            }
        }

        private void AddAbpServiceSelector(/*string moduleName, */string controllerName, ActionModel action)
        {
            var abpServiceSelectorModel = new SelectorModel
            {
                AttributeRouteModel = CreateAbpServiceAttributeRouteModel(/*moduleName, */controllerName, action)
            };

            abpServiceSelectorModel.ActionConstraints.Add(new HttpMethodActionConstraint(new[] { GetConventionalVerbForMethodName(action.ActionName) }));

            action.Selectors.Add(abpServiceSelectorModel);
        }

        private static AttributeRouteModel CreateAbpServiceAttributeRouteModel(/*string moduleName, */string controllerName, ActionModel action)
        {
            //return new AttributeRouteModel(new RouteAttribute($"api/services/{moduleName}/{controllerName}/{action.ActionName}"));
            return new AttributeRouteModel(new RouteAttribute($"api/services/{controllerName}/{action.ActionName}"));
        }

        private void ConfigureApiExplorer(ControllerModel controller)
        {
            if (controller.ApiExplorer.GroupName.IsNullOrEmpty())
            {
                controller.ApiExplorer.GroupName = controller.ControllerName;
            }

            if (controller.ApiExplorer.IsVisible == null)
            {
                controller.ApiExplorer.IsVisible = true;
            }
        }

        private void ConfigureParameters(ControllerModel controller)
        {
            foreach (var action in controller.Actions)
            {
                foreach (var prm in action.Parameters)
                {
                    if (prm.BindingInfo != null)
                    {
                        continue;
                    }

                    if (!TypeHelper.IsPrimitiveExtendedIncludingNullable(prm.ParameterInfo.ParameterType))
                    {
                        if (CanUseFormBodyBinding(action, prm))
                        {
                            prm.BindingInfo = BindingInfo.GetBindingInfo(new[] { new FromBodyAttribute() });
                        }
                    }
                }
            }
        }

        private bool CanUseFormBodyBinding(ActionModel action, ParameterModel parameter)
        {
            foreach (var selector in action.Selectors)
            {
                if (selector.ActionConstraints == null)
                {
                    continue;
                }

                foreach (var actionConstraint in selector.ActionConstraints)
                {
                    var httpMethodActionConstraint = actionConstraint as HttpMethodActionConstraint;
                    if (httpMethodActionConstraint == null)
                    {
                        continue;
                    }

                    if (httpMethodActionConstraint.HttpMethods.All(hm => hm.IsIn("GET", "DELETE", "TRACE", "HEAD")))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private string GetConventionalVerbForMethodName(string methodName)
        {
            if (methodName.StartsWith("Get", StringComparison.OrdinalIgnoreCase))
            {
                return "GET";
            }

            if (methodName.StartsWith("Put", StringComparison.OrdinalIgnoreCase) ||
                methodName.StartsWith("Update", StringComparison.OrdinalIgnoreCase))
            {
                return "PUT";
            }

            if (methodName.StartsWith("Delete", StringComparison.OrdinalIgnoreCase) ||
                methodName.StartsWith("Remove", StringComparison.OrdinalIgnoreCase))
            {
                return "DELETE";
            }

            if (methodName.StartsWith("Patch", StringComparison.OrdinalIgnoreCase))
            {
                return "PATCH";
            }

            if (methodName.StartsWith("Post", StringComparison.OrdinalIgnoreCase) ||
                methodName.StartsWith("Create", StringComparison.OrdinalIgnoreCase) ||
                methodName.StartsWith("Insert", StringComparison.OrdinalIgnoreCase))
            {
                return "POST";
            }

            //Default
            return "POST";
        }

        private static void RemoveEmptySelectors(IList<SelectorModel> selectors)
        {
            selectors
                .Where(IsEmptySelector)
                .ToList()
                .ForEach(s => selectors.Remove(s));
        }

        private static bool IsEmptySelector(SelectorModel selector)
        {
            return selector.AttributeRouteModel == null && selector.ActionConstraints.IsNullOrEmpty();
        }
    }
}