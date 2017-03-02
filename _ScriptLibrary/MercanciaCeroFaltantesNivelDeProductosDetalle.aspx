<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="MercanciaCeroFaltantesNivelDeProductosDetalle.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaCeroFaltantesNivelDeProductosDetalle" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>


<html>
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
        document.forms[0].action = "<%=strFormAction%>";
    }

    function strGetCustomDateTime() {
        document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
    return (true);
}

    function frmMercanciaCeroFaltantesResumen_onsubmit() {
        valida = true;
        return (valida);
    }

    function cmdRegresar_onclick() {
        //Ir a la página de Recepcion de Mercancía
        window.location = "MercanciaCeroFaltantesNivelDeProductos.aspx";
    }

    function cboZonaOperativa_onchange() {
        doSubmit();
    }

    function doSubmit() {
        document.forms[0].action = '<%= strThisPageName%>?strCmd=Consultar&intArticuloId=<%= strCodigoId()%>';
        document.forms[0].target = "ifrOculto";
        document.forms[0].submit();
    }

    function trim(stringToTrim) {
        return stringToTrim.replace(/^\s+|\s+$/g, "");
    }

    function cmdImprimir_onclick() {

        //Validacion de resultados
        var tablaTotal = document.getElementById('tblCeroFaltantes').innerHTML
        if (trim(tablaTotal) == '') {
            alert('No hay resultados de la consulta')
            return (false);
        }

        document.forms[0].action = "<%=strFormAction%>?strCmd=Imprimir&intArticuloId=<%= strCodigoId()%>";
        document.forms[0].target = "ifrOculto";
        document.forms[0].submit();
        document.forms[0].target = '';

        return (true);
    }

    function fnImprimir(strCeroFaltantes) {

        document.ifrPageToPrint.document.all.divContenido.innerHTML = strCeroFaltantes;
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
<form action="about:blank" method="post" name="frmMercanciaCeroFaltantesResumen" onSubmit="return frmMercanciaCeroFaltantesResumen_onsubmit()">
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
                <a href="Mercancia.aspx" class="txdmigaja">Mercancía</a>
                <span class="txdmigaja"> 
                : Cero Faltantes
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
                    Cero Faltantes - Detalle
                </span> 
                 <table  width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="tdtittablas">Artículo</td>
                        <td class="tdconttablas"><%= strCodigoId() %></td>
                    </tr>
                     <tr>
                        <td class="tdtittablas">Nombre</td>
                         <td class="tdconttablas"><%= strNombre()%></td>
                    </tr>
                     <tr>
                        <td class="tdtittablas">Categoría</td>
                         <td class="tdconttablas"><%= strCategoria()%></td>
                    </tr>
                     <tr>
                        <td class="tdtittablas">Abasto</td>
                         <td class="tdconttablas"><%= strAbasto()%></td>
                    </tr>
                     <tr>
                        <td class="tdtittablas">Zona Operativa</td>
                         <td class="tdpadleft5">
                             <select id="cboZonaOperativa" name="cboZonaOperativa" class="campotabla"  onchange="return cboZonaOperativa_onchange()">
                                 <%= LlenarControlZonaOpertaiva() %>
                             </select>
                         </td>
                    </tr>    
                 </table>
                
                <br> <div id="tblResultados"></div>
                <div id="tblCeroFaltantes" style="width:100%"></div>
                <div id="Div1" style="width:100%"></div>
              <br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()">
                   <input name="cmdImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick()"> 
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
    <div style="display:none;">
            <div id="divConsultaCeroFaltantes">
                <%= Me.strTablaConsultaCeroFaltantes()%>
            </div>            
        </div>
    <script language="JavaScript">
        var tablaTotal = document.getElementById('tblCeroFaltantes').innerHTML
        if (trim(tablaTotal) == '') {
            document.getElementById('Div1').innerHTML = 'No hay resultados de la consulta'
        }
        </script>
    <iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrPaginaenBlanco.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</html>
