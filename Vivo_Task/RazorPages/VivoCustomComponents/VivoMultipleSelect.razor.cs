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
    public partial class VivoMultipleSelect<T> : InputSelect<IEnumerable<T>>
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

        protected override void OnInitialized()
        {
            if (Value == null)
            {
                Value = [];
            }

            if (ValueExpression == null)
            {
                Expression<Func<IEnumerable<T>>> expression = () => Value;
                this.ValueExpression = expression;
            }
            Busy = false;
            base.OnInitialized();
        }
        private void OnItemsChanged(IEnumerable<T> newItems)
        {
            Value = newItems;
            ValueChanged.InvokeAsync(newItems);
        }

        protected override string? FormatValueAsString(IEnumerable<T>? value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            return base.FormatValueAsString(value);
        }
        protected override bool TryParseValueFromString(string value, out IEnumerable<T> result, out string validationErrorMessage)
        {

            if (typeof(T) == typeof(string))
            {
                result = value.Split(',').Cast<T>();
                validationErrorMessage = null;
                return true;
            }
            else if (typeof(T).IsEnum)
            {
                var splitvalue = value.Split(',');
                var success = BindConverter.TryConvertTo<IEnumerable<T>>(splitvalue, CultureInfo.CurrentCulture, out var parsedValue);
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
}
