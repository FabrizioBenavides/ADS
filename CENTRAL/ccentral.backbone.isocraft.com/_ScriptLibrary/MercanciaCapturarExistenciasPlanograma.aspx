<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaCapturarExistenciasPlanograma.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaCapturarExistenciasPlanograma" codePage="28605"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%    '====================================================================
    ' Page          : MercanciaCapturarExistenciasPlanograma.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para capturar la existencia real de un planograma
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Armando Calzada Mezura
    '                 J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Viernes, Noviembre 8, 2003
    '                 Lunes, Dicembre 29, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link href="../static/css/menu.css" rel="stylesheet">
<link href="../static/css/menu2.css" rel="stylesheet">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

var intSelectedElement = 0;
var intInputGenerales = 2;
var intTotalInput = intInputGenerales + <%=intTotalInput%>;
var checkIntegerOK = "0123456789";
var intCifraControl = 0;        
var intArticulosSinCaptura = 0; 

var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";

function blnIsNumber(checkStr) {

	var allValid = true;
  
	if (checkStr.length < 1) {
		allValid = false;
	}
  	else {
		for (i = 0;  i < checkStr.length;  i++)
		{
			ch = checkStr.charAt(i);
			for (j = 0;  j < checkIntegerOK.length;  j++)
				if (ch == checkIntegerOK.charAt(j))
					break;
				if (j == checkIntegerOK.length)
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
    document.forms[0].txtPlanogramaId.value = <%=intPlanogramaId%>;
    document.forms[0].txtFechaCaptura.value = "<%=dtmFechaCaptura%>";
    document.forms[0].txtNumeroPagina.value = <%=intPaginaId%>; 
    
    <%=strGeneracboHora%>
    <%=strGeneracboMinutos%>

	document.forms[0].elements[intSelectedElement].focus();
    return(true);
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}


function intPlanogramaId() {
	document.write("<%=intPlanogramaId%>");
	return(true);
}
function strPlanoNombre() {
	document.write("<%=strPlanoNombre%>");
	return(true);
}
function strRecordBrowserHTML() {
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}

function cmdCambioPagina_onClick(intPagina) {
	document.forms[0].txtNumeroPagina.value = intPagina;
	
	intObtenSuma();
		
	var regreso = true;	
	
	if (parseInt(intArticulosSinCaptura) > 0) {
		alert("Faltan artículos por registrar. Por favor capture un valor numérico para cada artículo.");
		regreso = false;
	}
				
	if (regreso && blnIsNumber(document.forms[0].txtCifraControl.value) == false) {
		alert("Por favor introduzca un valor numérico en el campo \"Cifra de control\".");
		document.forms[0].txtCifraControl.value = "";
		document.forms[0].txtCifraControl.focus();
		regreso = false;
	}
	if (regreso) {
	    regreso = ValidarCamposEtiben();
	}
	
	if (regreso && parseInt(document.forms[0].txtCifraControl.value) != intCifraControl) {
		alert("La existencia de artículos en el planograma no coincide con la cifra de control");
		document.forms[0].txtCifraControl.value = "";
		document.forms[0].txtCifraControl.focus();
        regreso = false;
	}
	
	if (regreso) {
		document.forms[0].action += "?strCmd=CambiarPagina";
		document.forms[0].submit();
	}
}

function cmdSalvarCaptura_onClick() {
	intObtenSuma();
	
	if (parseInt(intArticulosSinCaptura) > 0) {
		alert("Faltan artículos por registrar. Por favor capture un valor numérico para cada artículo.");
		return(false);
	}
	
	if (blnIsNumber(document.forms[0].txtCifraControl.value) == false) {
		alert("Por favor introduzca un valor numérico en el campo \"Cifra de control\".");
		document.forms[0].txtCifraControl.value = "";
		document.forms[0].txtCifraControl.focus();
		return(false);
	}
		
	if (ValidarCamposEtiben() == false) 
		return(false);
			
	if (parseInt(document.forms[0].txtCifraControl.value) != intCifraControl) {
		alert("La existencia de artículos en el planograma no coincide con la cifra de control");
		document.forms[0].txtCifraControl.value = "";
		document.forms[0].txtCifraControl.focus();
        return false;
	}
	
	document.forms[0].action += "?strCmd=SalvarCaptura&strCifraControl=" + document.forms[0].txtCifraControl.value + "&strHora=" + document.forms[0].cboHora.value + "&strMinutos=" + document.forms[0].cboMinutos.value ;
	document.forms[0].submit();
	return(false);
}

function intObtenSuma() {
	var theForm = document.forms[0];
	var strPrefijoCampo = "intArticuloId";
	var intTotal = 0;
	
	intArticulosSinCaptura = 0;
	intCifraControl = 0;	
		for (intElem = 0; intElem < document.forms[0].length; intElem++)
	{
		if (theForm.elements[intElem].name.indexOf(strPrefijoCampo) >= 0) {
			if (blnIsNumber(theForm.elements[intElem].value) == true) {
				intTotal += parseInt(theForm.elements[intElem].value);
				intCifraControl +=parseInt(theForm.elements[intElem].value);
			}
			else
			{
			  if (theForm.elements[intElem].length == 0) {
			     intArticulosSinCaptura+=1;
			  }			
			}
		}
	}
	
	
	return(intTotal);
}

function ValidarCamposEtiben() {
	var theForm = document.forms[0];
	var strPrefijoCampo = "intArticuloId";
	var intInicio = strPrefijoCampo.length;
	
	for (intElem = 0; intElem < document.forms[0].length; intElem++)
	{
		if (document.forms[0].elements[intElem].name.indexOf("cboHora") >= 0) {			
			if ((parseInt(document.forms[0].elements[intElem].value) < 0)) {
				alert("Seleccionar un valor entre 0 y 23 en el campo \"Hora\".");				
				document.forms[0].elements[intElem].focus();
				return(false);
			}
		}

	    if (document.forms[0].elements[intElem].name.indexOf("cboMinutos") >= 0) {			
			if ((parseInt(document.forms[0].elements[intElem].value) < 0)) {
				alert("Por favor introduzca un valor entre 0 y 59 en el campo \"Minutos\".");				
				document.forms[0].elements[intElem].focus();
				return(false);
			}
		}
		
		if (document.forms[0].elements[intElem].name.indexOf(strPrefijoCampo) >= 0) {
			if (blnIsNumber(document.forms[0].elements[intElem].value) == false) {
				alert("Por favor introduzca un valor numérico en el artículo ");
				document.forms[0].elements[intElem].value = "";
				document.forms[0].elements[intElem].focus();
				return(false);
			}
		}
	}	
	
	return(true);
}

function cmdCampo_onfocus(intValor) {

	intSelectedElement = intValor;
}

function cmdonKeyPressed() {
   if (event.keyCode == 13) {
       event.returnValue = false       

       intSelectedElement = (intSelectedElement + 1) % intTotalInput;       

       if (intSelectedElement >1) {		
		   document.forms[0].elements[intSelectedElement].focus();
		   document.forms[0].elements[intSelectedElement].select();
		}
		else {
		    document.forms[0].elements[intSelectedElement].focus();		   
	    }	
	    
	}
}

function btnSalir_onclick() {
   //strRedireccionaPOSAdmin('MercanciaCapturarInventarioRotativo.aspx&dtmFechaCaptura=17/02/2004');
   window.location="MercanciaCapturarInventarioRotativo.aspx?dtmFechaCaptura="+ "<%=dtmFechaCaptura%>";
}

//-->
</script>
</head>
<body onkeypress="cmdonKeyPressed();" leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmMercanciaCapturarExistenciasPlanograma" action="about:blank" method="post">
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
            <td width="10" bgcolor="#ffffff"> <img height="8" src="../static/images/pixel.gif" width="10"></td>
            <td class="tdmigaja" width="583"> <div id="ToPrintTxtMigaja"> <span class="txdmigaja">Está 
                en :</span><span class="txdmigaja"> <a class="txdmigaja" href="Mercancia.aspx">Mercancía</a> 
                : <a class="txdmigaja" href="javascript:strRedireccionaPOSAdmin('MercanciaInventarios.aspx')"> 
                Inventarios</a> : <a class="txdmigaja" href="javascript:strRedireccionaPOSAdmin('MercanciaInventariosRotativos.aspx')"> 
                Inventarios rotativos</a> : Capturar existencias de un planograma</span></div></td>
            <td class="tdfechahora" width="182"> <script language="JavaScript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td class="tdtablacont" valign="top" width="583"> <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr> 
                  <td class="tdtablacont" valign="top" width="100%" colspan="3"> 
                    <div id="ToPrintHtmContenido"> 
                      <p><span class="txtitulo">Capturar existencias de un planograma</span> 
                      </p>
                      <script language="JavaScript">crearDatosSucursal()</script>
                      <br>
                      <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr> 
                          <td class="tdtittablas" width="20%">Planograma:</td>
                          <td class="tdtittablas"> <script language="javascript">intPlanogramaId();</script> 
                            &nbsp; <script language="javascript">strPlanoNombre();</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas" width="20%">Hora de la Toma:</td>
                          <td class="tdconttablas"> <select class="campotabla" id="cboHora" onFocus="cmdCampo_onfocus(0)" name="cboHora">
                            </select> <select class="campotabla" id="cboMinutos" onFocus="cmdCampo_onfocus(1)" name="cboMinutos">
                            </select> </td>
                        </tr>
                      </table>
                      <br>
                      <script language="javascript">strRecordBrowserHTML();</script>
                      <br>
                      <input class="boton" onClick="return btnSalir_onclick()" type="button" value="Regresar" name="btnSalir">
                      &nbsp;&nbsp;&nbsp; 
                      <input class="boton" onClick="return cmdSalvarCaptura_onClick();" type="button" value="Salvar Captura" name="btnSalvar">
                      &nbsp;&nbsp;&nbsp; <br>
                    </div></td>
                </tr>
              </table></td>
            <td class="tdcolumnader" valign="top" width="182" rowspan="2"> <script language="javascript">strGeneraTablaAyuda(strPaginaAyuda);</script>	
            </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
          </tr>
        </table></td>
    </tr>
  </table>
  <input class="campotabla" readonly type="hidden" size="5" name="txtPlanogramaId">
  <input class="campotabla" readonly type="hidden" size="10" name="txtFechaCaptura">
  <input class="campotabla" readonly type="hidden" size="5" name="txtNumeroPagina">
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
  </script>
</form>
</body>
</html>
