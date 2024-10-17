namespace VehicleStoreAPI.Service.WeatherAppServices
{
    public interface IWeatherAppService<T> where T : class
    {
        public IEnumerable<T> GetData();
    }
}
