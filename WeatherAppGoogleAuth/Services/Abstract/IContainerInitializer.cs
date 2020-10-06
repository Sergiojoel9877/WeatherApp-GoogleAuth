using System;
namespace WeatherAppGoogleAuth.Services.Abstract
{
    /// <summary>
    /// IoC contract.
    /// </summary>
    public interface IContainerInitializer
    {
        void Initialize();
        void RegisterServices();
    }
}
