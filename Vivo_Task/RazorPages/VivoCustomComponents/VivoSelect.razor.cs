using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Vivo_Task.RazorPages.VivoCustomComponents
{
    public partial class VivoSelect<T> : InputSelect<T>
    {
        //[Parameter] public IEnumerable<T>? Values { get; set; }
        //[Parameter] public EventCallback<IEnumerable<T>> ItemsChanged { get; set; }
        //[Parameter] public Expression<Func<IEnumerable<T>>> ItemsValueExpression { get; set; }
        [Parameter] public required string LabelText { get; set; }
        [Parameter] public string? Id { get; set; }
        [Parameter] public string? Style { get; set; }
        [Parameter] public bool Rounded { get; set; } = false;
        [Parameter] public RenderFragment? Icon { get; set; }
        [Parameter] public IDictionary<string, ElementValue<T>> Data { get; set; }
        [Parameter] public Expression<Func<T>> ValidationFor { get; set; } = default!;
        [CascadingParameter] public EditContext Context { get; set; } = null;
        [Inject] public IJSRuntime JSRuntime { get; set; }
        bool Busy = true;
        /** Este parametro serve apenas para validar se o componente está dentro de um EDITFORM
         * caso sim ele executa funcionalidades de validação de propriedade **/

        //protected override void OnInitialized()
        //{
        //    if (Values == null)
        //    {
        //        Values = [];
        //    }

        //    if (ItemsValueExpression == null)
        //    {
        //        Expression<Func<IEnumerable<T>>> expression = () => Values;
        //        this.ItemsValueExpression = expression;
        //    }
        //    Busy = false;
        //    base.OnInitialized();
        //}
        //private void OnItemsChanged(IEnumerable<T> newItems)
        //{
        //    Values = newItems;
        //    ItemsChanged.InvokeAsync(newItems);
        //}

        protected override string? FormatValueAsString(T? value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            return base.FormatValueAsString(value);
        }

        protected override bool TryParseValueFromString(string value, out T result, out string validationErrorMessage)
        {
            if (typeof(T) == typeof(string))
            {
                result = (T)(object)value;
                validationErrorMessage = null;
                return true;
            }
            else if (typeof(T).IsEnum)
            {
                var success = BindConverter.TryConvertTo<T>(value, CultureInfo.CurrentCulture, out var parsedValue);
                if (success)
                {
                    result = parsedValue;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage = null;
                    return false;
                }
            }

            throw new InvalidOperationException($"não suporta o tipo '{typeof(T)}'.");
        }

    }
    public class ElementValue<T>(string text, T value)
    {
        public string Text { get; set; } = text;
        public T Value { get; set; } = value;
    }
}
