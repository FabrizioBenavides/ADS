// ====================================================================
// Page          : InvRotUtils.js
// Title         : Inventarios Rotativos
// Description   : Utilerias para Inventarios Rotativos
// Copyright     : 2003-2006 All rights reserved.
// Company       : Neitek Solutions S.A. de C.V.
// Author        : Carolina Caballero
// Version       : 1.0
// Last Modified : Monday, October 25th, 2003
// ====================================================================

var currentAction = ""

function setAction(aValue)
{	currentAction = aValue   }


function printDocument()
{
	if (document.forms[0].documentPrinted.value == "0")
	{
		document.ifrOculto.document.location.href="ImprimirDocumento.aspx"
		//window.open("ImprimirDocumento.aspx", "printDocument", "scroll=yes,resizable=yes,width=400,height=400,statusbar=no")
	}
}

function exportDocument()
{
	if (document.forms[0].documentExported.value == "0")
	{
		window.open("ExportarDocumento.aspx", "exportDocument", "menubar=yes,scrollbars=yes,resizable=yes,width=400,height=400,statusbar=no")
	}
}

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
	{
		params+= "&" + args[i] + "=" + args[i+1]
	}
	return params
}

function displayMessage( msg)
{
	alert(msg)
	window_onload()
}

