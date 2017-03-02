<%@ Page Language="vb" AutoEventWireup="false" Codebehind="VentasConsultarReportePorCategoria.aspx.vb" Inherits="com.isocraft.backbone.ccentral.VentasConsultarReportePorCategoria"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : VentasConsultarReportePorCategoria.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para consultar los reportes de entas	por categoria.
    ' Copyright     : 2007-2012 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Carlos Ruiz
    ' Version       : 1.0
    ' Last Modified : Friday, January 19, 2007
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
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
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/FuncionesString.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

function window_onload() {
      document.forms[0].action = "<%=strFormAction%>";

      document.forms[0].elements["cboAgrupar"].options[<%= intAgruparId %>].selected = true;

		<%= LlenarControlDivision() %>
		<%= LlenarControlCategoria() %>
		
     if (document.forms[0].elements["cboAgrupar"].value==1) {     
       document.forms[0].elements["cboCategoria"].disabled = true;
     }
	 else {     
       document.forms[0].elements["cboCategoria"].disabled = false;
     }
		
		document.forms[0].elements["txtFechaInicial"].value="<%=txtFechaInicial%>";
		document.forms[0].elements["txtFechaFinal"].value="<%=txtFechaFinal%>";
		

        return(true);
}

function strRecordBrowserHTML(){	
	document.write("<%=strRecordBrowser%>");	
	return(true);
}

function cboAgrupar_onchange() {

     if (document.forms[0].elements["cboAgrupar"].value==1) {     
       document.forms[0].elements["cboCategoria"].disabled = true;
     }
	 else {     
       document.forms[0].elements["cboCategoria"].disabled = false;
     }

     document.forms[0].elements["cboDivision"].selectedIndex = 0;
     document.forms[0].elements["cboCategoria"].selectedIndex = 0;
   
     document.forms[0].submit();
}

function cboDivision_onchange() {
    if (document.forms[0].elements["cboAgrupar"].value==2) {    
        document.forms[0].elements["cboCategoria"].selectedIndex = 0;
        document.forms[0].submit();
    }
}

function DoObjCalendar1(){
	if(document.forms(0).txtFechaInicial.readOnly==false){
		objCalendar1.popup();
	}
}

function DoObjCalendar2(){
	if(document.forms(0).txtFechaFinal.readOnly==false){
		objCalendar2.popup();
	}
}

function strGetCustomDateTime() {
	document.write("<%=Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}

function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
	return(true);
}


function txtFechaInicial_onblur() {
  valida=true;
  valida=blnValidarCampo(document.forms[0].elements('txtFechaInicial'),false,'Fecha',cintTipoCampoFecha,10,10,'')
  return(valida);
}

function txtFechaFinal_onblur() {
  valida=true;
  valida=blnValidarCampo(document.forms[0].elements('txtFechaFinal'),false,'Fecha',cintTipoCampoFecha,10,10,'')
  return(valida);
}

function cmdValidarForma() {
	if (!(blnValidarCampo(document.forms('frmVentasConsultarReportePorCategoria').elements('txtFechaInicial'),false,'Fecha',cintTipoCampoFecha,10,10,''))) {
	   return(false);
	}
	if (!(blnValidarCampo(document.forms('frmVentasConsultarReportePorCategoria').elements('txtFechaFinal'),false,'Fecha',cintTipoCampoFecha,10,10,''))) {
	   return(false);
	}
	return(true);

}

function cmdBuscarVentas_onSubmit() {
	if (cmdValidarForma()) {	
		document.forms[0].action = "<%=strFormAction%>?strCmd=Consultar";
		document.forms[0].submit();
		return(true);
	}
	else{
		return(false);
	}
}

function cmdImprimir_onclick() {
  document.ifrPageToPrint.document.all.divContenido.innerHTML = document.all.divImpresionHTML.innerHTML;        
  document.ifrPageToPrint.focus();
  window.print(); 
  return(true);
}

function cmdRegresar_onClick() {
	window.location="VentasDevoluciones.aspx"
	return(true);
}

function cmdPrint_onclick() {

    var currentAction = document.forms[0].action;
    var currentTarget = document.forms[0].target;

    document.forms[0].action += "?command=Print";
    document.forms[0].target = "_blank";
    document.forms[0].target = "PrintDocument";
    document.forms[0].submit();

    document.forms[0].action = currentAction;
    document.forms[0].target = currentTarget;

}

//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmVentasConsultarReportePorCategoria">
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
            <td width="583" class="tdmigaja"><span class="txdmigaja">Está en :</span><span class="txdmigaja"> 
              <a href="Ventas.aspx" class="txdmigaja">Ventas</a> : <a href="VentasDevoluciones.aspx" class="txdmigaja">Ventas 
              y devoluciones</a> : </span><span class="txdmigaja">Consultar ventas 
              acomuladas</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"><span class="txtitulo">Consultar 
                    reportes de ventas</span><span class="txcont">Seleccione el 
                    rango de fechas que desea consultar y oprima "Aceptar". </span> 
                    <script language="JavaScript">crearDatosSucursal()</script> 
                    <br> <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Configurar 
                    el reporte</span> <br> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td class="tdtittablas" width="75">Consultar:</td>
                        <td valign="middle" class="tdpadleft5"><select name="cboAgrupar" class="campotabla" onChange="return cboAgrupar_onchange()">
                            <option value="0" selected>Seleccionar</option>
                            <option value="1" selected>Division</option>
                            <option value="2" selected>Catgoria</option>
                          </select> </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas" width="75">División:</td>
                        <td valign="middle" class="tdpadleft5"><select name="cboDivision" class="campotabla" onChange="return cboDivision_onchange()">
                            <option value="0" selected>ť Todas las divisionesŤ</option>
                          </select> </td>
                      </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td class="tdtittablas" width="75">Categoría:</td>
                        <td valign="middle" class="tdpadleft5"><select name="cboCategoria" class="campotabla">
                            <option value="0" selected>ť Todas las categorías 
                            Ť</option>
                          </select> </td>
                      </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td class="tdtittablas" width="75">Fecha inicial:</td>
                        <td valign="middle" class="tdpadleft5" width="260"><input name="txtFechaInicial" type="text" class="campotabla" size="10" maxlength="10" > 
                          <img src="../static/images/icono_calendario.gif" width="20" style="CURSOR:hand" height="13"
																onClick="if(blnValidarCampo(document.forms[0].elements('txtFechaInicial'),false,'Fecha',cintTipoCampoFecha,10,10,'')){DoObjCalendar1();}"> 
                        </td>
                        <td class="tdtittablas" width="75">Fecha final:</td>
                        <td valign="middle" class="tdpadleft5"><input name="txtFechaFinal" type="text" class="campotabla" size="10" maxlength="10" > 
                          <img src="../static/images/icono_calendario.gif" width="20" style="CURSOR:hand" height="13"
																onClick="if(blnValidarCampo(document.forms[0].elements('txtFechaFinal'),false,'Fecha',cintTipoCampoFecha,10,10,'')){DoObjCalendar2();}"> 
                        </td>
                      </tr>
                    </table>
                    <br> <input name="btnBuscarProyecciones" type="button" class="boton" value="Ejecutar consulta"
													onClick="return cmdBuscarVentas_onSubmit();"> 
                    &nbsp;&nbsp; <br> <br> <script language="javascript">strRecordBrowserHTML();</script> <div id="divImpresionHTML" style="DISPLAY:none"> 
                    <%=strRecordBrowserImpresion%> </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	var objCalendar1 = new calendar1(document.forms['frmVentasConsultarReportePorCategoria'].elements['txtFechaInicial']);
    var objCalendar2 = new calendar1(document.forms['frmVentasConsultarReportePorCategoria'].elements['txtFechaFinal']);

	//-->
			</script>
</form>
<iframe name="PrintDocument" id="PrintDocument" frameborder="0" width="0" height="0" marginwidth="0" marginheight="0"></iframe>
<iframe name="ifrPageToPrint" src="ifrPaginaenBlanco.aspx" width="0" height="0"></iframe>
</body>
</HTML>
