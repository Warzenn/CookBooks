// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.







function addIngredientRow() {

    let container = document.getElementById("tbbodyIngredients");
    let ingArrayElementNumber = container.childElementCount;

    let ingredientsCount = ingArrayElementNumber + 1;

    

    let newRow = document.createElement("tr");
    let newData = document.createElement("td");
    let ingredientInput = document.createElement("input");

    newRow.id = "ingredient" + String(ingArrayElementNumber);
    container.appendChild(newRow);

    newRow.appendChild(newData);

    ingredientInput.setAttribute("asp-for", "Ingredients[" + ingArrayElementNumber + "].Ingredient");
    ingredientInput.setAttribute("class", "form-control");
    ingredientInput.setAttribute("placeholder", "Enter " + ingredientsCount + ". ingredients");
    ingredientInput.setAttribute("name", "Ingredients[" + ingArrayElementNumber + "].Ingredient");
    ingredientInput.setAttribute("value", "");
    newData.appendChild(ingredientInput);

    

}

function deleteIngredientRow() {

    let container = document.getElementById("tbbodyIngredients")
    let ingArrayElementNumber = container.childElementCount - 1;

    let ingredientId = "ingredient" + String(ingArrayElementNumber);
    let ingredientList = document.getElementById(ingredientId);
    if (ingArrayElementNumber == 0) {
        window.alert("Need at least 1 ingredient");
    }
    else {
        ingredientList.remove();
    }
}

function addInstructionRow() {

    let container = document.getElementById("tinstructions");
    let insArrayElementNumber = container.childElementCount;
    let instructionsCount = insArrayElementNumber + 1;
    let newRow = document.createElement("div");
    let instructionInput = document.createElement("textarea");
    let instructionValidationRow = document.createElement("span");

    newRow.id = "instruction" + String(insArrayElementNumber);

    container.appendChild(newRow);

    instructionInput.setAttribute("asp-for", "Instructions[" + insArrayElementNumber + "].instruction");
    instructionInput.setAttribute("class", "form-control");
    instructionInput.setAttribute("placeholder", "Enter " + instructionsCount + ". instructions");
    instructionInput.setAttribute("name", "Instructions[" + insArrayElementNumber + "].Instruction");
    instructionInput.setAttribute("rows", "1");
    instructionInput.setAttribute("value", "");

    newRow.appendChild(instructionInput);

    instructionValidationRow.setAttribute("asp-for", "Instructions[" + insArrayElementNumber + "].instruction");
    instructionValidationRow.setAttribute("class", "text-danger");
    newRow.appendChild(instructionValidationRow);
}

function deleteInstructionRow() {

    let container = document.getElementById("tinstructions")
    let insArrayElementNumber = container.childElementCount - 1;
    let instructionId = "instruction" + String(insArrayElementNumber);
    let instructionList = document.getElementById(instructionId);

    if (insArrayElementNumber == 0) {
        window.alert("Need at least 1 instruction");
    }
    else {
        instructionList.remove();
    }
}




//$(function () {
//    $("#btnAddNewIngredients").click(function () {
//        var count = $("#tbbodyIngredients >tr").length;
//        var i = $("#tbbodyIngredients >tr").length + 1;
//        $("#tbbodyIngredients").append("<tr><td> <input asp-for='Ingredients[" + count + "].Ingredient' name ='Ingredients[" + count + "].Ingredient' type='text-test' class='form-control' placeholder='Enter " + i + ". ingredients' ");
//        $("#tbbodyIngredients").append("<span asp-validation-for='Ingredients[" + count + "].Ingredient' class'text-danger'></span> ");
//    });
//});

//$(function () {
//    $("#btnAddNewInstructions").click(function () {
//        var count = $("#tbbodyInstructions >tr").length;
//        var i = $("#tbbodyInstructions >tr").length + 1;
//        $("#tbbodyInstructions").append("<tr><td> <input asp-for='Instructions[" + count + "].Instruction' name ='Instructions[" + count + "].Instruction' type='text-test' class='form-control' placeholder='Enter " + i + ". instructions' ");
//        $("#tbbodyInstructions").append("<span asp-validation-for='Instructions[" + count + "].Instruction' class'text-danger'></span> ");
//    });
//});

//$(function () {
//    $("#btnDeleteInstructions").click(function () {

//        $(this).("#tbbodyInstructions").removeChild();

//    });
//});



//$("#tbbody").append("<tr><td> <input class='form-control' name='Model.Instructions[" + count + "]'</td></tr>");