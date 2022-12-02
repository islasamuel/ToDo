using Microsoft.JSInterop;
using SIslas.ToDo.App.Model.DataBase;
using System;
using System.Threading.Tasks;

namespace SIslas.ToDo.App.Client.Helpers
{
    public class IJSExtensions : IDisposable
    {
        private readonly IJSRuntime js;

        public IJSExtensions(IJSRuntime js)
        {
            this.js = js;
        }

        public async ValueTask SetMessage(string mensaje, string tipo)
        {
            await js.InvokeVoidAsync("fncMessage", mensaje, tipo);
        }


        public async ValueTask<bool> SetConfirmMessage(string titulo, string mensaje)
        {
            return await js.InvokeAsync<bool>("fncConfirmMessage", titulo, mensaje);
        }

        public async ValueTask updateVista(int IdMeta, int totalTareas, int tareasCompletadas, decimal porcentaje)
        {
            await js.InvokeVoidAsync("fncModificaTareas", IdMeta, totalTareas, tareasCompletadas, porcentaje);

        }

        public void Dispose()
        {
        }

    }
}
