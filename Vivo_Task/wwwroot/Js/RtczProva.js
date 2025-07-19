//function TopFildset() {
//    document.getElementById("page-home").style.display = "block";
//}

window.TopFildset = function (idFieldSet) {
    var element = document.getElementById(idFieldSet);
    var idInterpolation = `${idFieldSet}fieldsetexpc`;
    var elementField = document.getElementById(idInterpolation);
    var ariaExpandedValue = elementField.getAttribute("aria-expanded");
    //var fielsetElement = document.getElementById(element.id + 'fieldsetexpc');
    //var elementValue = fielsetElement.getAttribute('aria-expanded');


    if (element) {

        if (ariaExpandedValue === 'true') {

            if (element.style.display === 'flex') {

                /* element.classList.remove('TransitionAdd');*/

                element.classList.add('TransitionRemove');

                setTimeout(function () {
                    element.style.display = 'none';
                }, 100);

            }

        } else {

            var previousElement = element.previousElementSibling;

            if (ariaExpandedValue === 'false') {


                element.classList.remove('TransitionRemove')

                element.style.display = 'flex';

                element.classList.add('TransitionAdd');
            }
        }
    }
};


