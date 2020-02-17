using Autofac;
using ContactInformation.BLL;
using ContactInformation.BLL.Interface;
using ContactInformation.Controllers;
using ContactInformation.DAL;
using ContactInformation.DAL.Interface;

namespace ContactInformation.DependencyMapper
{
    public class ApiMapper : Module
    {
        /// <summary>
        /// Load method
        /// </summary>
        /// <param name="builder">builder</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContactController>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.ContactInformationService = e.Context.Resolve<IContactInformationService>();
            });            

            builder.RegisterType<ContactInformationService>().As<IContactInformationService>().InstancePerRequest().OnActivated(e =>
            {
                e.Instance.ContactInformationDataManager = e.Context.Resolve<IContactInformationDataManager>();
            });
            builder.RegisterType<ContactInformationDataManagerJSON>().As<IContactInformationDataManager>();
            
        }
    }
}