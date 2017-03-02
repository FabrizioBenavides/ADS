<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="RentaEspaciosDetalle.aspx.vb" Inherits="com.isocraft.backbone.ccentral.RentaEspaciosDetalle1" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>

<html >
<head >
    <title>Sistema Administrador de Sucursal</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link rel="stylesheet" href="../static/css/menu.css">
    <link rel="stylesheet" href="../static/css/menu2.css">
    <link rel="stylesheet" href="../static/css/estilo.css">
    <script language="JavaScript" src="../static/scripts/Tools.js"></script>
    <script language="JavaScript" src="../static/scripts/menu.js"></script>
    <script language="JavaScript" src="../static/scripts/menu_items.js"></script>
    <script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
    <script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
    <script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
    <script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
    <script language="JavaScript" id="clientEventHandlersJS">
<!--
        function window_onload() {
            MM_preloadImages('../static/images/bsalir_on.gif', '../static/images/bayuda_on.gif');
            document.forms[0].action = '<%=strFormAction%>';

            var strCodigoId = "<%= strCodigoId()%>";
    }

    function strGetCustomDateTime() {
        document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
        return (true);
    }

        function frmDetalleRentaEspacios_onsubmit() {
        valida = true;
        return (valida);
    }

    function cmdRegresar_onclick() {
        //Ir a la página de Consulta de Renta de Espacios en Sucursal.
        window.location = "RentaEspaciosConsulta.aspx";
    }

    function cmdImprimir_onclick() {
        
        var intExhibicionCodigo = document.getElementById('hdnCodigoId').value;

        document.forms[0].action = '<%=strThisPageName%>?strCmd=cmdImprimir&intExhibicionCodigo=' + intExhibicionCodigo;
        document.forms[0].target = "ifrOculto";
        document.forms[0].submit();
        document.forms[0].target = '';

        return (true);
    }

    function fnImprimir(strExhibicionDetalle) {

        document.ifrPageToPrint.document.all.divContenido.innerHTML = strExhibicionDetalle;
        document.ifrPageToPrint.focus();
        window.print();

    }

    //-->
</script>
    <style>
            #Div1 {
            color:red;
            }
    </style>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmDetalleRentaEspacios" onSubmit="return frmDetalleRentaEspacios_onsubmit()">
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
            <td width="583" class="tdmigaja">
                <span class="txdmigaja">Está en : 
                </span>
                <a href="Mercancia.aspx" class="txdmigaja">Sucursal</a>
                <span class="txdmigaja"> 
                : Exhibiciones Adicionales - Detalle
                </span>
            </td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont">
                <script language="JavaScript">crearDatosSucursal()</script>
                <br /><span class="txtitulo">
                    <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle">
                    Exhibiciones Adicionales - Detalle			
                </span> 
                 <table  width="100%" border="0" cellpadding="0" cellspacing="0">
                     <tr>
                         <td class="txsubtitulo" colspan="4">
                             <span>Datos Generales</span>
                         </td>
                    </tr>
                    <tr>
                        <td class="tdtittablas" width="140px">División:</td>
                        <td class="tdconttablas" width="153px"><%= strDivision() %></td>
                        <td class="tdtittablas" width="140px">Categoría:</td>
                        <td class="tdconttablas" width="150px"><%= strCategoria()%></td>
                    </tr>
                     <tr>
                         <td class="tdtittablas" width="140px">CATMAN:</td>
                         <td class="tdconttablas" width="153px"><%= strCatman()%></td>
                         <td class="tdtittablas" width="140px">Socio Comercial:</td>
                         <td class="tdconttablas" width="150px"><%= strSocioComercial() %></td>
                    </tr>
                     <tr>
                         <td class="tdtittablas" width="140px">Proveedor:</td>
                         <td class="tdconttablas" colspan="3"><%= strProveedor()%></td>
                    </tr>
                     <tr>
                    </tr>
                 </table>
                <br />
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="txsubtitulo" colspan="4">
                            <span>Datos Exhibición</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdtittablas" width="140px">Tipo de Renta:</td>
                        <td class="tdconttablas" width="153px"><%= strTipoRenta() %></td>
                        <td class="tdtittablas" width="140px">Tipo de Exhibición:</td>
                        <td class="tdconttablas" width="150px"><%= strTipoExhibicion()%></td>
                    </tr>
                    <tr>
                        <td class="tdtittablas" width="140px">Espacio Publicitario:</td>
                        <td class="tdconttablas" width="153px"><%= strEspacioPublicitario() %></td>
                        <td class="tdtittablas" width="140px">Nombre de la Exhibición:</td>
                        <td class="tdconttablas" width="150px"><%= strNombreExhibicion() %></td>
                    </tr>
                    <tr>
                        <td class="tdtittablas" width="140px">Plan de Salida:</td>
                        <td class="tdconttablas" width="153px"><%= strPlanSalida() %></td>
                        <td class="tdtittablas" width="140px">Comentarios:</td>
                        <td class="tdconttablas" width="150px"><%= strComentariosPlanSalida() %></td>
                    </tr>
                    <tr>
                        <td class="tdtittablas" width="140px">Tipo de Planograma:</td>
                        <td class="tdconttablas" width="153px"><%= strTipoPlanograma() %></td>
                        <td class="tdtittablas" width="140px">Planograma:</td>
                        <td class="tdconttablas" width="150px"><%= strPlanograma() %></td>
                    </tr>
                    <tr>
                        <td class="tdtittablas" width="140px">Estatus:</td>
                        <td class="tdconttablas" width="153px"><%= strEstatus() %></td>
                    </tr>
                </table>
                <br />
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="txsubtitulo"colspan="4">Vigencia:
                            <!--span class="txsubtitulo">Vigencia:</span>-->
                        </td>
                    </tr>
                    <tr>
                        <td class="tdtittablas" width="140px">Fecha Inicio:</td>
                         <td class="tdconttablas" width="153px"><%= strFechaInicio()%></td>
                        <td class="tdtittablas" width="140px">Fecha Fin:</td>
                         <td class="tdconttablas" width="150px"><%= strFechaFin() %></td>
                    </tr>
                </table>
                <br />
                 <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="50%">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="tdtittablas">Implementado:</td>
                                    <td class="tdconttablas" colspan="2"><input type="checkbox" id="chkImplementado" name="chkImpleme ntado" <%= strImplementado() %> disabled="disabled" /></td>
                                </tr>
                                <tr>
                                    <td class="tdtittablas">Motivo:</td>
                                    <td class="tdconttablas" colspan="2"><%= strRazon() %></td>
                                </tr>
                            </table>
                        </td>
                        <td width="50%">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="tdconttablas"><img src="<%= strRutaImagen()%>" style="margin:10px; border:1px solid #ccc; width:300px; height:275px;" ></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                   </table>
                <br> <div id="tblResultados"></div>
                <div id="tblCeroFaltantes" style="width:100%"></div>
                <div id="Div1" style="width:100%"></div>
              <br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()">
                   <input id="cmdImprimir" name="cmdImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick()"> 
                <input type="hidden" id="hdnCodigoId" name="hdnCodigoId" value='<%= strCodigoId()%>'/>
              <br> <br> </td>
            <td width="187" rowspan="2" valign="top" class="tdcolumnader"> 
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
    new menu(MENU_ITEMS, MENU_POS);
    new menu(MENU_ITEMS2, MENU_POS2);
    //-->
  </script>
</form>
    <iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrPaginaenBlanco.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</html>