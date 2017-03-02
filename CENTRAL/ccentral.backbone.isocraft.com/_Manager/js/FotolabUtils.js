// ====================================================================
// Page          : FotolabUtils.js
// Title         : Fotolab
// Description   : Utilerias para Fotolab
// Copyright     : 2003-2006 All rights reserved.
// Company       : Neitek Solutions S.A. de C.V.
// Author        : Enrique Longoria
// Version       : 1.0
// Last Modified : Monday, January 31th, 2005
// ====================================================================
/*
var currentAction = ""

function setAction(aValue)
{	currentAction = aValue   }
*/
/*
function exportDocument()
{
	if (document.forms[0].documentExported.value == "0")
	{
		window.open("../ExportarDocumento.aspx", "exportDocument", "menubar=yes,scrollbars=yes,resizable=yes,width=400,height=400,statusbar=no")
	}
}
*/
function openCalendar(obj)
{
	calendar1(obj)
	cal_popup1(obj.value)
}
function openCalendar_Central(objCal)
{
	calendar(objCal.value, objCal)
	cal_popup(objCal.value)
}

/*
function validateInteger(val)
{
	if (val == "")
		return "Valor requerido"
	else if (isNaN (val))
		return "Debe ser número válido"
	else if (val.indexOf(".") >= 0)
		return "Debe ser número entero"
	else 
	{
		var intVal = parseInt (val)
		if (isNaN (intVal) )
			return "Debe ser número válido"
	}
	return ""
}

function buildParams (args)
{
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{params+= "&" + args[i] + "=" + args[i+1]}
	return params
}

function displayMessage( msg)
{
	alert(msg)
	window_onload()
}
*/

//--------------------------------------------------------
//funciones que permiten buscar a un control de una forma
//--------------------------------------------------------
//Elongoria 8/Feb/05

/* SELECT */
function getSelectObject(complexName)
{	var formObj = eval("document.forms[0]." + getObjNameSel(complexName));
	return formObj
}
function getObjNameSel(complexName)
{
		elements = document.forms[0].getElementsByTagName("select");
		formName = document.forms[0].id;
		for(i=0; i<elements.length; i++)
		{
			if(elements[i].id.indexOf(complexName)>=0)
			{	complexName = elements[i].id;	}
		}	
		return complexName
}		

/* TEXTAREA */
function getTextAreaObject(complexName)
{	var formObj = eval("document.forms[0]." + getObjNameTA(complexName));
	return formObj
}
function getObjNameTA(complexName)
{		elements = document.forms[0].getElementsByTagName("textarea");
		formName = document.forms[0].id;
		for(i=0; i<elements.length; i++)
		{
			if(elements[i].id.indexOf(complexName)>=0)
			{	complexName = elements[i].id;	}
		}	
		return complexName
}

/* INPUT */
function getInputObject(complexName)
{	var formObj = eval("document.forms[0]." + getObjName(complexName));
	return formObj
}
function getObjName(complexName)
{		elements = document.forms[0].getElementsByTagName("input");
		formName = document.forms[0].id;
		for(i=0; i<elements.length; i++)
		{
			if(elements[i].id.indexOf(complexName)>=0)
			{	complexName = elements[i].id;	}
		}	
		return complexName
}	


//--------------------------------------------------------
// Funcion que te permite obtener el Valor seleccionado
// de un RadioButton  y lo asigan a un text o hidden
//--------------------------------------------------------
//Elongoria 8/Feb/05
//radioObj= nombre del objeto tipo Radio al cual se desea tomar su valor seleccionado
//idObj= nombre del objeto tipo hidden o text al cual se desea asignar el valor del radio seleccionado
function getSelectedRadioValue(radioName,idName)
{	
	var radioObj =getInputObject(radioName)
	var idObj =getInputObject(idName)
	for (i=0;i<radioObj.length ; i++)
	{
		if(	radioObj[i].checked)
		{idObj.value=radioObj[i].id;}
	}
}	


//--------------------------------------------------------
// Funcion que abre el popup para seleccionar un valor
//--------------------------------------------------------
//Elongoria 8/Feb/05
function openPopup(header,screenName,strFilterValues, idObj,displayObj,extraParams,nextfocus)
{	
if (nextfocus  == null)
nextfocus="";
window.open("PopupDocumento.aspx?header="+header+"&screenName="+screenName+"&idObj="+idObj+"&displayObj="+displayObj+"&strFilterValues="+strFilterValues+extraParams+"&nextfocus="+nextfocus, "Benavides", "scroll=yes,resizable=no,width=600,height=500,statusbar=no")
}

	
//--------------------------------------------------------
// Funcion que abre una nueva ventana para realizar x accion
//--------------------------------------------------------
//Elongoria 16/Feb/05
function newWindow(urlPage, xSize, ySize)
{	
	window.open(urlPage, "Benavides", "scroll=yes,resizable=no,width="+xSize+",height="+ySize+",statusbar=no")
}
