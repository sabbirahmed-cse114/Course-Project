using Autofac;
using iTransition.Forms.Application;
using iTransition.Forms.Application.Services;
using iTransition.Forms.Domain.RepositoryContracts;
using iTransition.Forms.Infrastructure;
using iTransition.Forms.Infrastructure.Repositories;
using iTransition.Forms.Infrastructure.UnitOfWorks;

namespace iTransition.Forms.Web
{
    public class WebModule(string connectionString, string migrationAssembly) : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TemplateManagementService>()
               .As<ITemplateManagementService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<TemplateRepository>()
                .As<ITemplateRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TagManagementService>()
                .As<ITagManagementService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TagRepository>()
                .As<ITagRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TopicManagementService>()
                .As<ITopicManagementService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TopicRepository>()
                .As<ITopicRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FormsUnitOfWork>()
                .As<IFormsUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", connectionString)
                .WithParameter("migrationAssembly", migrationAssembly)
                .InstancePerLifetimeScope();
        }
    }
}
