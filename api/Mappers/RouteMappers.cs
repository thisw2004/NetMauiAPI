using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Route;
using api.Models;

namespace api.Mappers
{
    public static class RouteMappers
    {
        //define here routes like my model,otherwise you will get error bc there is a default model route with other content etc.
        public static RouteDTO ToRouteDTO(this Routes routeModel){
            return new RouteDTO{
                //set here all data you want to be displayed.
                ID = routeModel.ID,
                Name = routeModel.Name,
                Description = routeModel.Description,
                Distance = routeModel.Distance,
                StartPoint = routeModel.StartPoint,
                EndPoint = routeModel.EndPoint,
                
            };
        }
    }
}