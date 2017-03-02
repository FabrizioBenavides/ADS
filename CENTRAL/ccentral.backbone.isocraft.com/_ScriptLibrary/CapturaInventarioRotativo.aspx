<%@ Page CodeBehind="CapturaInventarioRotativo.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsCapturaInventarioRotativo" Explicit="True" Trace="False" Strict="True" codePage="1252"  EnableSessionState="true" enableViewState="False" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : CapturaInventarioRotativo.aspx
    ' Title         : Inventarios Rotativos Por Listados
    ' Description   : Captura de Inventarios Rotativos Por Listados
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.
    ' Author        : Carolina Caballero
    ' Version       : 1.0
    ' Last Modified : Monday, October 25th, 2003 	
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<LINK href="../static/css/menu.css" rel="stylesheet">
<LINK href="../static/css/menu2.css" rel="stylesheet">
<LINK href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/Calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/InvRotUtils.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--



var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";

function strCompaniaSucursal() {
	document.write(<%=intCompaniaId%> + " - " + <%=intSucursalId%>);
	return(true);
}

function strSucursalNombre() {
	document.write("&nbsp;"+"<%=strSucursalNombre%>");
	return(true);
}

function strGetCustomDateTime() {
	document.write("<%=Now.toString("dd/MM/yyyy - HH:mm:ss") %>");
	return(true);
}

function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
	return(true);
}

function validarInfo()
{ 
  var valida=true

  if (window.document.forms[0].listadoEstatus.value=="CC")
  {
	return valida
  }
  var index =0
  var item =0
  var aux
  var cifraControlCalculada = 0
  
  for (index=0; index<=45; index++)
  {
	eval("aux = window.document.forms[0].amount" + index)
	if (aux == undefined)
	{
		//se acabaron los registros
		break;
	}

	result = validateInteger(aux.value)
	if (result != "" )
	{	
		eval("var articuloId = window.document.forms[0].id_" + index + ".value")
		alert ("Error capturando existencia del artículo " + articuloId + " : " + result)
		eval ("window.document.forms[0].amount" + index + ".focus()")
		eval ("window.document.forms[0].amount" + index + ".select()")
		valida = false
		break
	}
	cifraControlCalculada += parseInt (aux.value) 
  }//ends for
  
  if (valida)
  {
	var cifraControlCapturada = window.document.forms[0].intCifraControl.value
	result = validateInteger(cifraControlCapturada)
	if (result == "")
	{
		if (cifraControlCalculada != parseInt(cifraControlCapturada) )
		{
			alert("La cifra de control no coincide con la suma de las existencias. Favor de verificar.")
			window.document.forms[0].intCifraControl.value = ""
			window.document.forms[0].intCifraControl.focus()
			valida = false	
		}
	}
	else
	{
		alert ("Error capturando cifra de control : " + result)
		valida = false
	}
  }
  return valida
}

function validateForm() 
{
  var result = false
  if (currentAction == "ImprimirDiferencias")
  {
	result= true
  }
  else
  {
	result = validarInfo ()
  }
  
  return result;
}

function window_onload(){
  //  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  //  document.forms[0].action="<%=strFormAction%>";
  if  (window.document.forms[0].amount0 != undefined)
  {
	window.document.forms[0].amount0.focus()
	window.document.forms[0].amount0.select()
  }
  
  if ('<%= Request("strCmd") %>' == 'ImprimirDiferencias' )
  {
	printDocument()
  }

}

function openCalendar(obj)
{
	calendar1(obj)
	cal_popup1(obj.value)
}

function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];
    
	if (action == "grabar" || action == "paginaAnterior")
	{	
		if (!validateForm() )
		{	return false } 
	}
	
	{
		var params = ""
		for (i=1; i < (args.length-1); i +=2)
		{
			params+= "&" + args[i] + "=" + args[i+1]
		}
		document.forms[0].action = "CapturaInventarioRotativo.aspx?strCmd=" + action + params
		document.forms[0].submit();  
	}
}

  function moveToNext(name, current, lastOne, lastToMove)
  {
    if (window.event.keyCode == 13) 
    { 
	   if (lastOne == -1 && current==-1)
	   {
			doSubmit ("grabar")
	   }
	   else if (lastOne == (current+1) ) 
       {
		 if  (window.document.forms[0].intCifraControl != undefined)
		 {
			window.document.forms[0].intCifraControl.focus()
			window.document.forms[0].intCifraControl.select()
		 }
		 else
		 {	window.document.forms[0].btnSave.focus()
		 }
       }
       else 
       { 
         eval('window.document.forms[0].' + name + (current+1) + '.focus()')
         eval('window.document.forms[0].' + name + (current+1) + '.select()')
	   }
	 } 
  }
  
//-->
</script>
</HEAD>
<body leftMargin="0" topMargin="0" onload="return window_onload()" marginwidth="0" marginheight="0">
<form id="frmConsulta" name="frmConsulta" onsubmit="return validateForm()" method="post">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98" width="100%"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td valign="top" height="34" width="100%"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td width="100%"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgColor="#ffffff"><IMG height="8" src="../static/images/pixel.gif" width="10"></td>
            <td class="tdmigaja" width="583"><span class="txdmigaja">Está en : 
              SUCURSAL : INV.&nbsp;ROTATIVO&nbsp;: Captura </span></td>
            <td class="tdfechahora" width="182"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td vAlign="top" width="583"> <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                <tr> 
                  <td class="tdtablacont" vAlign="top" width="100%" colSpan="3"><span class="txtitulo">Capturar 
                    Inventarios Rotativos por Listados</span><span class="txcontenido">&nbsp;Llene 
                    los campos de Existencia, al final capturar la cifra de control, 
                    y seleccionar "Salvar Captura"</span><span class="txsubtitulo"><br>
                    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                      <tr> 
                        <td class="tdtittablas" width="10%">Sucursal: </td>
                        <td class="tdconttablas" width="40%"><input type="text" id="sucursalNombre" name="sucursalNombre" size="70" readonly class="fieldborderless" value="<%= sucursalNombre %>"></td>
                        <TD class="tdtittablas" width="30%">Fecha y Hora Actual:</TD>
                        <TD class="tdconttablas" width="20%"><input type="text" id="fechaActual" name="fechaActual" size="20" readonly class="fieldborderless" value="<%= fechaActual %>"></TD>
                      </tr>
                      <tr> 
                        <td class="tdtittablas">Listado:</td>
                        <td class="tdconttablas"><input type="text" id="listadoNombre" name="listadoNombre" size="50" readonly class="fieldborderless" value="<%= listadoNombre %>"></td>
                        <TD class="tdtittablas">Fecha Toma inventario:</TD>
                        <TD class="tdconttablas"><input type="text" id="dtmSelectedDate" name="dtmSelectedDate" size="12" readonly class="fieldborderless" value="<%= dtmSelectedDate %>"></TD>
                      </tr>
                    </table>
                    <br>
                    <%= strRecordBrowserHTML %> <br>
                    <input id="status" type="hidden" name="status" value="<%= status %>">
                    <input id="listadoEstatus" type="hidden" name="listadoEstatus" value="<%= listadoEstatus %>">
                    <% 	if Me.status = Me.IMPRESION_DIFERENCIAS then  %>
                    <input id="btnImprimirDiferencias" type="button" value="Imprimir Diferencias" name="btnImprimirDiferencias"
														class="boton" onclick="doSubmit('ImprimirDiferencias')">
                    <% 	elseif me.listadoEstatus = "CC" then %>
                    <input id="btnPrevious" type="button" value="Página Anterior" name="btnPrevious" class="boton"
														onclick="doSubmit('paginaAnterior')">
                    <input id="btnSave" type="button" value="Página Siguiente" name="btnSave" class="boton"
														onclick="doSubmit('grabar')">
                    <% 	else %>
                    <input id="btnPrevious" type="button" value="Página Anterior" name="btnPrevious" class="boton"
														onclick="doSubmit('paginaAnterior')">
                    <input id="btnSave" type="button" value="Salva Captura" name="btnSave" class="boton" onclick="doSubmit('grabar')">
                    <% 	end if %>
                    </span></td>
                </tr>
              </table></td>
            <td class="tdcolumnader" vAlign="top" width="182" rowSpan="2"> <script language="javascript">strGeneraTablaAyuda('');</script> 
            </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
          </tr>
        </table></td>
    </tr>
    <tr> 
      <td><input id="intListadoId" type="hidden" name="intListadoId" value="<%= intListadoId %>" > 
        <input id="intOrdenamiento" type="hidden" name="intOrdenamiento" value="<%= intOrdenamiento %>" > 
        <input type="hidden" value="0" name="documentPrinted"> <input type="hidden" name="actionName"></td>
    </tr>
  </table>
  <script language="JavaScript">
				<!--
				new menu (MENU_ITEMS, MENU_POS);
				new menu (MENU_ITEMS2, MENU_POS2);
				//-->
			</script>
</form>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
</body>
</HTML>
