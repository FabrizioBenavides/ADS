<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaPedidoDirectoMayoristaStock.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaPedidoDirectoMayoristaStock" codePage="28592" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaPedidoDirectoMayoristaStock.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Consulta el Stock de los Mayoristas para Pedidos Directos al Mayorista 
    ' Copyright     : 2014 All rights reserved.
    ' Company       : Farmacias Benavides
    ' Author        : [JAHD] 
    ' Version       : 1.0
    ' Last Modified : 
    '                 01 de Mayo 2014 [JAHD] 
    '====================================================================
%>
<link href="../static/css/menu.css" rel="stylesheet">
<link href="../static/css/menu2.css" rel="stylesheet">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" src="../static/scripts/cnfg.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--

function LTrim(s){
	// Devuelve una cadena sin los espacios del principio
	var i=0;
	var j=0;
	
	// Busca el primer caracter <> de un espacio
	for(i=0; i<=s.length-1; i++)
		if(s.substring(i,i+1) != ' '){
			j=i;
			break;
		}
	return s.substring(j, s.length);
}

function RTrim(s){
	// Quita los espacios en blanco del final de la cadena
	var j=0;
	
	// Busca el último caracter <> de un espacio
	for(var i=s.length-1; i>-1; i--)
		if(s.substring(i,i+1) != ' '){
			j=i;
			break;
		}
	return s.substring(0, j+1);
}

function Trim(s){
	// Quita los espacios del principio y del final
	return LTrim(RTrim(s));
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
} 

function txtArticuloId_onfocus() {
 document.forms[0].txtArticuloId.select();
 return(true);
}

function fnUpdArticuloPorIframe(strRecordBrowserHTML, intError) {
    document.all.divArticuloStock.innerHTML = strRecordBrowserHTML;	
	
	if(intError!=0) {
		alert('Artículo no encontrado');
		document.forms[0].elements['txtArticuloId'].focus(); 
    }   
}

function cmdConsultar_onclick() { 
   var strArticulo;
   var intCuentaApostrofes;
      
   if (document.forms[0].txtArticuloId.value == "") {return(true);}
   
   strArticulo = document.forms[0].elements['txtArticuloId'].value;
   intCuentaApostrofes = strArticulo.search("'");
   
   if (intCuentaApostrofes != -1){
       alert("No se deben de capturar apostrofes");
       document.forms[0].elements['txtArticuloId'].value = '';
       document.forms[0].elements['txtArticuloId'].focus();
       return(false);
   }
   
   if (document.forms[0].txtArticuloId.value != "") {
       document.forms[0].action = "<%=strFormAction%>?strCmd=BuscarArticulo&<%=strFormActionParameters%>";
       document.forms[0].target="ifrOculto";
	   document.forms(0).submit();
       document.forms[0].target='';
       return(true);
	}
	else{
		alert("Teclear número de artículo o descripción");
		document.forms[0].txtArticuloId.focus();
        return(false); 
	    }
}

function cmdRegresar_onClick() {
   window.location.href = "MercanciaEntradas.aspx";  
   return(true);
}

function window_onload() {     
    return(true);                      
}

function cmdonKeyPressed(intObjeto,tecla) {
 if (tecla == 13 || tecla==9) { 
	   if (intObjeto==1) {//articulo
           document.forms(0).cmdConsultar.focus();         
       }	   
       event.returnValue = false;      
   }  
}

//-->
</script>
</HEAD>
<body leftMargin="0" topMargin="0" onload="return window_onload()" marginwidth="0" marginheight="0">
<form name="frmMercanciaPedidoDirectoMayoristaStock" action="about:blank" method="post">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98" width="100%"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td valign="top" height="34"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td > <table width="780" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgColor="#ffffff"> <img height="8" src="../static/images/pixel.gif" width="10"></td>
            <td class="tdmigaja" width="583"><span class="txdmigaja">Está en : 
              </span><a class="txdmigaja" href="Mercancia.aspx"> Mercancía</a> 
              <span class="txdmigaja">: <a class="txdmigaja" href="MercanciaPedidoDirectoMayorista.aspx"> 
              Pedido Directo Mayoristas</a></span><span class="txdmigaja"> </span><span class="txdmigaja">: 
              </span><span class="txdmigaja"> </span><span class="txdmigaja"></span><span class="txdmigaja">Consulta 
              Stock</span></td>
            <td class="tdfechahora" width="182"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td vAlign="top" width="583"> <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                <tr> 
                  <td class="tdtablacont" vAlign="top" width="100%"> <br> <table class="tdenvolventetablas" width="100%">
                      <tr> 
                        <td class="tdtittablas3" align="left" width="10%">Articulo:</td>
                        <td align="left" class="txtitintabla" width="60%"> <input class="campotablahabilitadoderecha" id="txtArticuloId" 
																onFocus="return txtArticuloId_onfocus()" type="text" maxlength="20" size="20" name="txtArticuloId"
																autocomplete="off" onKeyPress="cmdonKeyPressed(1,event.keyCode);" tabindex="1" > 
                        </td>
                        <td class="tdtittablas3" align="center" vAlign="middle" width="30%"> 
                          <input class="boton" id="cmdConsultar" onclick="return cmdConsultar_onclick()" type="button" value="Consultar" name="cmdConsultar" tabindex="2"> 
                          &nbsp;&nbsp; <input class="boton" onclick="return cmdRegresar_onClick()" type="button" value="Regresar" name="cmdRegresar" tabindex="-1"> 
                        </td>
                      </tr>
                      <tr> 
                        <td  colspan="3"class="tdtittablas3" align="left" width="60%" ><br> 
                          <div id="divArticuloStock" name="divArticuloStock"></div></td>
                      </tr>
                    </table></td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          </tr>
          <tr> 
            <td class="tdbottom" colSpan="2"><script language="JavaScript">crearTablaFooter()</script></td>
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
<iframe name="ifrOculto" width="0" height="0"></iframe>
</body>
</HTML>
