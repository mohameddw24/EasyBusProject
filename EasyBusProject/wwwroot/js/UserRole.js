

function prepareFormData() {
    alert("js")
    console.log("first");

    var idIsAdminDict = {};
    var IsAdmininputs = document.querySelectorAll('.IsAdmin');
    var Idinputs = document.querySelectorAll('.Id');

    idIsAdminDict[Idinputs[0].value] = IsAdmininputs[0].checked;

    for (int i = 0; i < Idinputs.length ; i++) {
        idIsAdminDict[Idinputs[i].value] = IsAdmininputs[i].checked;
    }

    

     //var tst = inputs[0].nextElementSibling.value;
    //IsAdmininputs.forEach(function (input) {

    //        idIsAdminDict[input.nextElementSibling.value] = input.checked;

    //    });

    var hiddenInput = document.createElement('input');
    hiddenInput.type = 'text';
    hiddenInput.name = 'IdIsAdminDict';
    hiddenInput.value = JSON.stringify(idIsAdminDict);

        document.querySelector('form').appendChild(hiddenInput);

    console.log(idIsAdminDict);


    return true;
}
