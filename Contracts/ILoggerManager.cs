namespace Contracts
{
    public interface ILoggerManager
    {
        //void LogInfo(string message);
        //void LogWarn(string message);
        //void LogDebug(string message);
        //void LogError(string message);

        //Metodo Genera Mensaje Tipo Informativo 
        //con parametro un mensaje
        void LogInfo(string message);

        //Metodo Genera Mensaje Tipo Informativo 
        //con parametro un mensaje y objeto Excepcion
        void LogInfo(string message, Exception ex);

        //Metodo Genera Mensaje Tipo Advertencia 
        //con parametro un mensaje
        void LogWarn(string message);

        //Metodo Genera Mensaje Tipo Advertencia 
        //con parametro un mensaje y objeto Excepcion
        void LogWarn(string message, Exception ex);

        //Metodo Genera Mensaje Tipo Error 
        //con parametro un mensaje
        void LogError(string message);

        //Metodo Genera Mensaje Tipo Error 
        //con parametro un mensaje y objeto Excepcion
        void LogError(string message, Exception ex);

        void LogDebug(string message);
    }
}
