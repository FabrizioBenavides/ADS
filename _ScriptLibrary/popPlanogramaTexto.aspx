<%@ Page Language="vb" AutoEventWireup="false" Codebehind="popPlanogramaTexto.aspx.vb" Inherits="com.isocraft.backbone.ccentral.popPlanogramaTexto" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<% 
'====================================================================
' Page          : popPlanogramaTexto.aspx
' Title         : Administracion POS y BackOffice
' Description   :  
' Copyright     : 2012
' Company       : BENAVIDES
' Author        : J.Antonio Hernández Dávila
' Version       : 1.0
' Last Modified : 
'                
'====================================================================	
%>
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--
var blnSinSeleccion =true;

// Funcion donde Eliminamos los guiones de alguna cadena.
function strEliminaGuiones(objCampo){
 var strInicial, strFinal, strResultado;
 
 strInicial = objCampo;
 strFinal = strInicial.split("-");

    strResultado = '';
    for (intContador = 0; intContador < strFinal.length; intContador++){
         strResultado = strResultado + strFinal[intContador];  
    }
    
 return(strResultado); 
}

function window_onload() {
	document.forms[0].action = "<%=strFormAction%>";
	return(true);
}

function cmdImprimir_onclick() 
{

	if (window.print) 
	{
		document.ifrPageToPrint.document.all.ToPrintTxtFecha.innerHTML    =document.all.ToPrintTxtFecha.innerText;
		document.ifrPageToPrint.document.all.ToPrintHtmContenido.innerHTML= document.all.ToPrintHtmContenido.innerHTML;
		document.ifrPageToPrint.focus();
		window.print();        
	} 
	else 
		alert("Tu navegador no soporta la función: Print.");
		
	return(false);
}


function cmdCerrar_onclick() {	
	window.close();	
	return(true);
}

//-->
		</script>
</HEAD>
<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0" onunload="return window_onunload()">
<form name="frmpopPlanogramaTexto" action="about:blank" method="post">
  <table height="158" cellspacing="0" cellpadding="0" width="100%" bgcolor="#ffffff" border="0">
    <tr> 
      <td class="tdlogopop" colspan="2" height="54"><script language="javascript">crearTablaHeaderPop()</script></td>
    </tr>
    <tr> 
      <td valign="top" height="10" width="100%" colspan="2"><img src="../static/images/pixel.gif" width="1" height="10"></td>
    </tr>
    <tr> 
      <td colspan="2"><script language="JavaScript">crearDatosSucursal()</script></td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td valign="top" width="99%" height="10">&nbsp;</td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td align="right"><input name="cmdImprimir" type="submit" class="boton" id="cmdImprimir" value="Imprimir" onclick="return cmdImprimir_onclick()"> 
        <input name="cmdCerrar" type="submit" class="boton" id="cmdCerrar" value="Cerrar" onclick="return cmdCerrar_onclick()"> 
      </td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td valign="top" height="30"> <div id="ToPrintHtmContenido"><span class="txtitulo"><%= strPlanograma%></span><%= strRecordBrowserHTML %></div></td>
    </tr>
  </table>
</form>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</HTML>
