<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaConsultarPlanogramas.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaConsultarPlanogramas" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : MercanciaConsultarPlanogramas.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para consultar los planos de ubicación de los productos.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Carlos E. Pérez Torres
    ' Version       : 1.0
    ' Last Modified : October 27, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
	'                 20 de Abril 2012 [JAHD] DATOS DEL PLANOGRAMA
	'                 15 de Octubre 2012 [JAHD] Ruta de documentos PDF	
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";

function window_onload() {
		document.forms[0].action = "<%=strFormAction%>"; 
		document.forms[0].elements["txtPlanograma"].value = "<%=strPlanograma %>";
		document.forms[0].elements["txttotalPlanogramas"].value = "<%=intTotalPlanogramas %>";
		document.forms[0].elements["cboOrden"].options[<%=intOrdenId %>].selected = true;
        return(true);
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}

function btnSalir_onclick() {
	document.location.href='MercanciaInventariosPlanogramas.aspx';
	return(true);
}

function cmdEjecutar_onclick() {
   document.forms[0].action = "<%=strFormAction%>";
   document.forms[0].submit();
}

function cmdImprimir(){                                                                            
   document.forms[0].action = "<%=strFormAction%>?strCmd=Imprimir";
   document.forms[0].target="ifrOculto";
   document.forms[0].submit();
   document.forms[0].target='';
}

function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0]; 
	var strPlanoId = args[2];
	
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{
		params+= "&" + args[i] + "=" + args[i+1]
	}
	
    if (action=="VerTexto") {       
       url = 'popPlanogramaTexto.aspx?intPlanoId=' + strPlanoId;       
       var WinVerTexto = window.open(url,'PopPlanogramaTexto','width=820,height=620,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );
       
       return;
    }
    
    if (action=="VerGrafico") {           	   
       url =  strUrlADSDoc() + 'PDF/Planos/Pa' + strPlanoId + '.PDF'  
       var WinVerGrafico = window.open(url,'PopPlanogramaGrafico','width=820,height=620,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );
       
       return;
    }
    
	document.forms[0].action = 'MercanciaConsultarPlanogramas.aspx?strCmd=' + action + '&' + params;
	document.forms[0].submit(); 
	document.forms[0].target='';	
}
function cboOrden_onchange() {
   document.forms[0].action = "<%=strFormAction%>";
   document.forms[0].submit();
}

function fnImprimir(strPlanogramas) {
  document.ifrPageToPrint.document.all.divContenido.innerHTML= strPlanogramas;
  document.ifrPageToPrint.focus();
  window.print();      
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0"  onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaConsultarPlanogramas">
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
            <td width="10" bgcolor="#FFFFFF"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Est&aacute; 
                en : </span><a href="Mercancia.aspx" class="txdmigaja">Mercanc&iacute;a</a><span class="txdmigaja"> 
                : <a href="MercanciaInventarios.aspx" class="txdmigaja">Inventarios</a></span><span class="txdmigaja"> 
                </span><span class="txdmigaja">:</span><span class="txdmigaja"><a href="MercanciaInventariosPlanogramas.aspx" class="txdmigaja"> 
                Planogramas</a></span><span class="txdmigaja"> :</span> <span class="txdmigaja"></span> 
                <span class="txdmigaja">Consultar planogramas</span></div></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p><span class="txtitulo">Consultar planogramas</span><span class="txcontenido">Los 
                      siguientes son los planogramas autorizados para su sucursal. 
                      Para cada uno, puede elegir entre ver el listado de productos 
                      asociados al planograma o ver la representaci&oacute;n gr&aacute;fica 
                      del mismo.</span> 
                      <script language="JavaScript">crearDatosSucursal()</script>
                      <br>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                      <tr> 
                        <td class="tdtittablas" width="30%">Planogramas asignados:</td>
                        <td class="tdconttablas" width="70%" valign="top"><input class="campotablaresultado" id="txttotalPlanogramas" readonly maxlength="40"size="40" border="0" name="txttotalPlanogramas"></td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas" width="30%">Planograma busqueda:</td>
                        <td class="tdconttablas" width="70%"valign="top"> <input class="campotabla" id="txtPlanograma" type="text" autocomplete="off"  maxlength="45" size="45" name="txtPlanograma"  value='<%=Request("strPlanograma")%>'> 
                        </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas" width="30%">Ordenar:</td>
                        <td class="tdconttablas" width="70%"valign="top"> <select name="cboOrden" class="campotabla" id="cboOrden" onchange="return cboOrden_onchange()">
                            <option value="0">Planograma</option>
                            <option value="1">Mueble</option>
                            <option value="2">Actualización</option>
                            <option value="3">Asignación</option>
                          </select> </td>
                      </tr>
                      <tr> 
                        <td valign="top" height="5" width="100%" colspan="2"><img src="../static/images/pixel.gif" width="1" height="5"></td>
                      </tr>
                    </table>
                    <input name="btnSalir"    type="button" class="boton" value="Regresar" onClick="return btnSalir_onclick();"> 
                    &nbsp; <input name="cmdEjecutar" type="button" class="boton" value="Consultar" onclick="return cmdEjecutar_onclick()"> 
                    &nbsp; <input name="btnImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir();"> 
                    <br> <br> <div id="divPlanograma"><%= strConsultarPlanogramas%> 
                    </div>
                    <br> </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <p> 
    <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
</script>
</form>
<iframe name="ifrOculto" width="0" height="0"></iframe>
<iframe name="ifrPageToPrint" src="ifrPaginaenBlanco.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</html>
