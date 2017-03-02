<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="SucursalConsultaBanorte.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsSucursalConsultaBanorte" codePage="28592" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : SucursalConsultaBanorte.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para accesar al ws banorte 
    ' Copyright     : 2013 All rights reserved.
    ' Company       : 
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : 18 JUL 2013
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


function cmdConsultar_onclick() {
   var valida=true;
   if(valida){ if(document.forms[0].elements['txtAutorizacionId'].value==0 || (document.forms[0].elements['txtAutorizacionId'].value).length < 1){valida=false;} }
	
   //Autorizacion
   if(valida) {	      
    document.forms[0].action = "<%=strFormAction%>?strCmd=Autorizacion&strAutorizacionId=" + document.forms[0].elements['txtAutorizacionId'].value;
    document.forms[0].target="ifrOculto";
   	document.forms(0).submit();
    document.forms[0].target='';
    return(true);    
   }  	
       
}

function fnUpdAutorizacionPorIframe (strCedula, strNombreMedico, strNomina, strFamiliar, strNombreDerechohabiente, strFecha,strRespuesta) {
					   
    document.forms(0).txtCedula.value = strCedula;
    document.forms(0).txtNombreMedico.value = strNombreMedico;
    document.forms(0).txtNomina.value = strNomina;
    document.forms(0).txtFamiliar.value = strFamiliar;
    document.forms(0).txtNombreDerechohabiente.value = strNombreDerechohabiente;
    document.forms(0).txtFecha.value = strFecha;
	document.forms(0).txtRespuesta.value = strRespuesta;
}

function cmdRegresar_onClick() {
   window.location.href = "MercanciaEntradas.aspx";  
   return(true);
}


function window_onload() {
    return(true);                      
}

//-->
</script>
</HEAD>
<body leftMargin="0" topMargin="0" onload="return window_onload()" marginwidth="0" marginheight="0">
<form name="frmSucursalConsultaBanorte" action="about:blank" method="post">
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
            <td width="583" class="tdmigaja"><span class="txdmigaja">Está en : 
              </span><a href="javascript:strRedireccionaPOSAdmin('Sucursal.aspx')" class="txdmigaja"> 
              Sucursal</a><span class="txdmigaja"> : Autorización Banorte</span></td>
            <td class="tdfechahora" width="182"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td vAlign="top" width="583"> <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                <tr> 
                  <td class="tdtablacont" vAlign="top" width="100%"> <br> <table width="100%" class="tdenvolventetablas">
                      <tr> 
                        <td class="tdtittablas3" align="left" width="20%">Autorización:</td>
                        <td class="tdtittablas3" align="left" width="50%"><input class="campotabla" id="txtAutorizacionId" maxLength="20" size="20" name="txtAutorizacionId" autocomplete="off" ></td>
                        <td class="tdtittablas3" align="center" width="30%"><input class="boton" id="cmdConsultar" onclick="return cmdConsultar_onclick()" type="button" value="Consultar" name="cmdConsultar" tabindex="2"> 
                        </td>
                      </tr>
                    </table>
                    <span class="txtitulo"><br>
                    <input readOnly   class="campotablaresultadoblanco" type="text" size="70" name="txtRespuesta" tabindex="-1">
                    <br>
                    </span> <span class="txsubtitulo"><br>
                    <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Detalle 
                    Autorización <br>
                    </span> <table class="tdenvolventetablas" width="100%">
                      <tr> 
                        <td class="tdtittablas3" width="20%" >Cedula</td>
                        <td class="txtitintabla" vAlign="middle" width="80%"><input class="campotablaresultadoenvolventeazul" readOnly type="text" size="30" name="txtCedula" tabindex="-1"> 
                        </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3" width="20%" >Nombre Medico</td>
                        <td class="txtitintabla" vAlign="middle" width="80%"><input class="campotablaresultadoenvolventeazul" readOnly type="text" size="30" name="txtNombreMedico" tabindex="-1"> 
                        </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3" width="20%" >Nomina</td>
                        <td class="txtitintabla" vAlign="middle" width="80%"><input class="campotablaresultadoenvolventeazul" readOnly type="text" size="30" name="txtNomina" tabindex="-1"> 
                        </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3" width="20%" >Familiar</td>
                        <td class="txtitintabla" vAlign="middle" width="80%"><input class="campotablaresultadoenvolventeazul" readOnly type="text" size="30" name="txtFamiliar" tabindex="-1"> 
                        </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3" width="20%" >Derecho habiente</td>
                        <td class="txtitintabla" vAlign="middle" width="80%"><input class="campotablaresultadoenvolventeazul" readOnly type="text" size="30" name="txtNombreDerechohabiente" tabindex="-1"> 
                        </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3" width="20%" >Fecha</td>
                        <td class="txtitintabla" vAlign="middle" width="80%"><input class="campotablaresultadoenvolventeazul" readOnly type="text" size="30" name="txtFecha" tabindex="-1"> 
                        </td>
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
