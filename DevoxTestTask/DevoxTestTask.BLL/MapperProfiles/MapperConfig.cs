using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DevoxTestTask.DAL.Entities;
using DevoxTestTaskCommon.Models;

namespace DevoxTestTask.BLL.MapperProfiles
{
    public class MapperConfig: Profile
    {
        public MapperConfig() {

            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectDTO, Project>();
        }
    }
}
