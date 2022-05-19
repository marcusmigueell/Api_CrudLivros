namespace Api.Net_Core.Mvc {

    public class RoteamentoPadrao {

        public static Task TratamentoPadrao(HttpContext context) {

            var classe = Convert.ToString(context.GetRouteValue("classe"));
            var nomeMetodo = Convert.ToString(context.GetRouteValue("metodo"));

            var nomeCompleto = $"Api.Net_Core.Logica.{classe}Logica";

            var tipo = Type.GetType(nomeCompleto);
            var metodo = tipo.GetMethods().Where(m => m.Name == nomeMetodo).First();
            var requestDelegate = (RequestDelegate)Delegate.CreateDelegate(typeof(RequestDelegate), metodo);

            return requestDelegate.Invoke(context);

        }
    }
}