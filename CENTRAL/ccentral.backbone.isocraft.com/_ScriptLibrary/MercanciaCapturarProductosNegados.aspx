<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaCapturarProductosNegados.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaCapturarProductosNegados" codePage="28605"%>
<html>
<head>
<%    '====================================================================
    ' Page          : MercanciaCapturarProductosNegados.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para capturar el registro de productos negados
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Armando Calzada Mezura
    ' Version       : 1.0
    ' Last Modified : Lunes, Octubre 27, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<title>Sistema Administrador de Sucursal</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/FuncionesString.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--




var checkOK = "0123456789";

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function blnIsNumber(checkStr) {

	var allValid = true;
  
	if (checkStr.length < 1) {
		allValid = false;
	}
  	else {
		for (i = 0;  i < checkStr.length;  i++)
		{
			ch = checkStr.charAt(i);
			for (j = 0;  j < checkOK.length;  j++)
				if (ch == checkOK.charAt(j))
					break;
				if (j == checkOK.length)
				{
					allValid = false;
					break;
				}
		}
  }
  
  return (allValid);
}

function window_onload() {
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
    document.forms[0].action = "<%=strFormAction%>";
    document.forms[0].txtInventarioNegadoFolioId.value = <%=intInventarioNegadoFolioId%>;
           
    <%=strcboEmpleadoAutorizado%>
	<% if intError = 0 then %>
		document.forms[0].txtArticuloId.value = "<%=strArticuloId%>";
        document.forms[0].hdnArticuloAnteriorId.value = "<%=strArticuloId%>";
		document.forms[0].txtCantidadVeces.value = "<%=strCantidadVeces%>";
		document.forms[0].txtArticuloDescripcion.value = "<%=strArticuloDescripcion%>";
	<% elseif intError = -100 then %>
			alert("Artículo no existe. Favor de ingresar un código existente");
	<% end if %>
	
	strCmd = "<%=strCmd%>";
	
	// Mantiene el foco en el Articulo a capturar	
	if (strCmd.length > 0){
	 document.forms(0).txtArticuloId.focus();
	} 

    return(true);
}

function strMostrarFolio(objInventarioNegadoFolioId){
	<% if intInventarioNegadoFolioId>0 then %>
	document.write("<table><tr><td class='tdconttablas'>Folio: <%=intInventarioNegadoFolioId%></td></tr></table>")
	<% end if %>
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}

function intCompaniaId() {
	return(<%=intCompaniaId%>);
}

function intSucursalId() {
	return(<%=intSucursalId%>);
}

function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
}

function strCompaniaSucursal() {
	document.write(intCompaniaId() + " - " + intSucursalId());
	return(true);
}

function strSucursalNombre() {
	document.write("<%=strSucursalNombre%>");
	return(true);
}

// Genera el RecordBrowser
function strRecordBrowserHTML() {
    document.write("<%=strRecordBrowserHTML%>");
	return(true);
}

function cmdImprimir_onclick() {
    if (window.print) {
        document.ifrPageToPrint.document.all.ToPrintTxtMigaja.innerHTML=document.all.ToPrintTxtMigaja.innerText;
        document.ifrPageToPrint.document.all.ToPrintTxtFecha.innerHTML=document.all.ToPrintTxtFecha.innerText;
        document.ifrPageToPrint.document.all.ToPrintTxtSucursal.innerHTML=document.all.ToPrintTxtSucursal.innerText;
        document.ifrPageToPrint.document.all.ToPrintHtmContenido.innerHTML=document.all.ToPrintHtmContenido.innerHTML;
        document.ifrPageToPrint.focus();		
        document.ifrPageToPrint.document.all.btnAgregar.style.display = "none";
        window.print(); 
    } else {
        alert("Tu navegador no soporta la función: Print.")
    }    
	return(true);
}

function cmdBuscarArticulo_onClick() {
	
	if (document.forms[0].txtArticuloId.value!="") {
      if (!isNaN(document.forms[0].txtArticuloId.value)) {       
			document.forms[0].action = "<%=strFormAction%>?strCmd=Consultar";
            document.forms[0].target='ifrOculto';
            document.forms[0].submit();
            document.forms[0].target='';						
			return(true);
		}
		else {
			url = "PopArticulo.aspx?strArticulo=txtArticuloId&strArticuloNombreId=txtArticuloDescripcion&strArticuloIdNombre=" + document.forms[0].txtArticuloId.value;
			width = 500;
			height = 540;
			return Pop(url, width, height);
		}
	}
	else {
		alert("Teclear código o descripcion del artículo a buscar");
        return false;
	}
}

function Pop(url, width, height) {
    var Win = window.open(url,'Pop','width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
	 return (false);
}

function cmdAgregar_onclick() {
	var theForm = document.forms[0];

	if (theForm.cboEmpleadoAutorizado.value == 0) {
		alert("Seleccionar un empleado autorizado");
		theForm.cboEmpleadoAutorizado.focus();
        return(false);
	}
	
	if (Trim(theForm.txtArticuloId.value) == "" || Trim(theForm.txtArticuloId.value) == " ") {
		alert("Teclear código o descripcion del artículo a agregar");
		theForm.txtArticuloId.focus();
        return(false);
	}
	
	if (isNaN(theForm.txtArticuloId.value)==true){
		alert("Capturar correctamente el número de articulo");
		document.forms[0].txtArticuloId.select();
		document.forms[0].txtArticuloId.focus();
		return(false);
	}
		
	if (theForm.txtArticuloId.value == 0) {
		alert("Teclear código o descripcion del artículo a agregar");
		theForm.txtArticuloId.focus();
        return(false);
	}
		
	if (theForm.txtCantidadVeces.value == "") {
		alert("Teclear cantidad a registrar");
		theForm.txtCantidadVeces.focus();
        return(false);
	}

	if (blnIsNumber(theForm.txtCantidadVeces.value) == false) {
		alert("Por favor introduzca un valor numérico en el concepto \"Veces que se negó\".");
		theForm.txtCantidadVeces.value = "";
        theForm.txtCantidadVeces.focus();
		return(false);
    }
    
    if (theForm.txtCantidadVeces.value < 1 || theForm.txtCantidadVeces.value > 99) {
		alert("Cantidad fuera del rango permitido, 1 a 99");
		theForm.txtCantidadVeces.focus();
        return(false);
	}
	theForm.action = "<%=strFormAction%>?strCmd=Agregar";
	theForm.submit();
	return(false);
}

function btnRegresar_onclick() {
 //Redireccionamos al home de entradas
   document.location = 'MercanciaInventariosProductosNegados.aspx';
}

function fnBuscaArticulo(strArticulo,strArticuloDescripcion,intEncontrado){

  if (parseInt(intEncontrado) == 1){
      document.forms[0].txtArticuloId.value=strArticulo;
      document.forms[0].txtArticuloDescripcion.value=strArticuloDescripcion;
      document.forms[0].hdnArticuloAnteriorId.value=strArticulo;
      document.forms[0].txtCantidadVeces.focus();
  }
      
  if (parseInt(intEncontrado) == 0){
      document.forms[0].txtArticuloId.value=''; 
      document.forms[0].txtArticuloDescripcion.value='';      
      document.forms[0].txtArticuloId.focus();
      alert('Número de artículo no existe.');      
   }                     
} 

function txtCantidadVeces_onfocus() {
  document.forms[0].elements['objLupa'].click();
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaCapturarProductosNegados">
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
            <td width="10" bgcolor="#ffffff"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Está 
                en :</span><span class="txdmigaja"> <a href="Mercancia.aspx" class="txdmigaja">Mercancía</a> 
                : <a href="MercanciaInventarios.aspx" class="txdmigaja">Inventarios</a> 
                : <a href="MercanciaInventariosProductosNegados.aspx" class="txdmigaja">Productos 
                negados</a> : Capturar productos negados</span></div></td>
            <td width="182" class="tdfechahora"> <script language="JavaScript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <div id="ToPrintHtmContenido"> <span class="txtitulo">Capturar 
                      productos negados </span><span class="txcontenido"> Elija 
                      un empleado autorizado para captura de productos negados, 
                      y después capture el código de un producto y la cantidad 
                      de veces que se negó al cliente. </span> <br>
                      <script language="JavaScript">crearDatosSucursal()</script>
                      <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                          <td width="138" class="tdtittablas">Empleado autorizado:</td>
                          <td colspan="3" class="tdconttablas"> <select name="cboEmpleadoAutorizado" class="campotabla">
                              <option value="0" selected>Elija un empleado autorizado</option>
                            </select> </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Código de negado:</td>
                          <td width="124" valign="middle" class="tdpadleft5"><input name="txtArticuloId" type="text" class="campotabla" size="16" maxlength="16" onKeyDown="if(event.keyCode==13){document.forms[0].elements['objLupa'].click();} if(event.keyCode==9){document.forms[0].elements['objLupa'].click();}"> 
                            &nbsp; <a href="javascript:;" onClick="return cmdBuscarArticulo_onClick();"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="absMiddle" name="objLupa"></a></td>
                          <td width="306" colspan="2" valign="middle" class="tdconttablasrojo"><input class="campotablaresultado" type="text" size="40" name="txtArticuloDescripcion" readonly> 
                            <input class="campotabla" type="hidden" size="5" name="txtInventarioNegadoFolioId" readonly> 
                            <input type="hidden" size="5" name="hdnArticuloAnteriorId" readonly> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Veces que se negó:</td>
                          <td width="124" valign="middle" class="tdpadleft5"><input name="txtCantidadVeces" type="text" class="campotabla" size="16" maxlength="4" onKeyDown="if(event.keyCode==13){document.forms[0].elements['btnAgregar'].click();};if(event.keyCode==9){document.forms[0].elements['btnAgregar'].click();}" onfocus="return txtCantidadVeces_onfocus()"> 
                            &nbsp;</td>
                          <td width="306" colspan="2" valign="middle" class="tdconttablas">&nbsp;</td>
                        </tr>
                      </table>
                      <input name="btnAgregar" type="button" class="boton" value="Agregar artículo" onClick="return cmdAgregar_onclick();">
                      <br>
                      <script language="javascript">strMostrarFolio();</script>
                      <script language="javascript">strRecordBrowserHTML();</script>
                    </div>
                    <br> <input name="btnRegresar" type="button" class="boton" value="Regresar" onClick="return btnRegresar_onclick()"> 
                    &nbsp;&nbsp; <input name="btnImprimir" type="button" class="boton" value="Imprimir la lista" onClick="return cmdImprimir_onclick();"> 
                  </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"><script language="javascript">strGeneraTablaAyuda('');</script> 
            </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
</script>
</form>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
<iframe name="ifrOculto" width="0" height="0"></iframe>
</body>
</html>
