namespace ControleJogo.Aplicacao.Mappers
{
    public class AutoMapperInicialize
    {
        public static void Inicialize()
        {
            AutoMapper.Mapper.Initialize(config => 
            {
                config.AddProfile<DomainToViewModelProfile>();
                //config.AddProfile<ViewModelToDomain>();
            });
        }
    }
}
