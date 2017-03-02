<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="RentaEspaciosConsulta.aspx.vb" Inherits="com.isocraft.backbone.ccentral.RentaEspaciosConsulta1" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>

<html>
<head>
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

            <%= LlenarControlMotivo()%>

            document.getElementById('tblDetalle').style.display = 'none';
            
            var Implementado = "<%=strImplementado()%>";
            
            if (Implementado == "True") {
                
                parent.document.getElementById('chkImplementado').checked = true;
                parent.document.getElementById('cboMotivo').selectedIndex = 0;
                parent.document.getElementById('cboMotivo').disabled = true;
            }
            else {

                parent.document.getElementById('chkImplementado').checked = false;
                parent.document.getElementById('cboMotivo').disabled = false;
            }

            parent.document.getElementById('tdPlanSalida').innerHTML = "<%= strPlanSalida()%>";
            parent.document.getElementById('tdFechaFin').innerHTML = "<%= strFechaFin()%>";
            parent.document.getElementById('cboMotivo').value = "<%= strMotivo()%>";
            parent.document.getElementById('txtRazon').value = "<%= strComentarios()%>";
            
            parent.document.all.imgDetalle.src = "<%= strRutaImagen()%>";
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

    function doSubmit(c, t, p) {
        document.getElementById('tblDetalle').style.display = 'none';
        if (p == null) {
            p = document.getElementById('txtCurrentPage').value;
        }
        else {
            document.getElementById('txtCurrentPage').value = p;
        }
        document.forms[0].action =
        '<%= strThisPageName%>?strCmd=cmdConsultar&pager=true&p=' + p;
        document.forms[0].target = "ifrOculto";
        document.forms[0].submit();
}

    function txtRazon_onKeyPress(e) {
        var key = window.event ? e.keyCode : e.wich;

        if (document.getElementById('chkImplementado').checked == true) {
            return false;
        }
        //No se permiten caracteres especiales para el Articulo.
        if ((key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123) || (key == 32)) {
            return true;
        }
        else {
            return false;
        }
    }

    //Guarda la razon por la cual no se implemento
    function cmdGuardar_onclick() {
        var intExhibicionCodigo = document.getElementById('hdnCodigoId').value;
        
        //Solo se captura si no ha sido implementado y no este vacio el campo "Razon".
        if ((document.getElementById('chkImplementado').checked == false) && trim(document.getElementById('txtRazon').value) == '') {
            alert('Capture los comentarios');
            return (false);
        }
        else if ((document.getElementById('chkImplementado').checked == false) && (document.getElementById('cboMotivo').selectedIndex == 0)) {
            alert('Seleccione el motivo');
            return (false);
        
        }
        else {
            document.forms[0].action = '<%=strThisPageName%>?strCmd=cmdGuardar&intExhibicionCodigo=' + intExhibicionCodigo;//"<= strCodigoExhibicionId()%>";
            document.forms[0].target = "ifrOculto";
            document.forms[0].submit();
            return (true);
        }
    }

    function cmdImprimir_onclick() {
        document.forms[0].action = '<%=strThisPageName%>?strCmd=cmdImprimir';
        document.forms[0].target = "ifrOculto";
        document.forms[0].submit();
        return (true);
    }

    function fnImprimir(strExhibicionesAdicionales) {

        document.ifrPageToPrint.document.all.divContenido.innerHTML = strExhibicionesAdicionales;
        document.ifrPageToPrint.focus();
        window.print();

    }

    function trim(stringToTrim) {
        return stringToTrim.replace(/^\s+|\s+$/g, "");
    }

    function frmConsultaRentaEspacios_onsubmit() {
        return (true);
    }

    function cmdVerificarAccion_onclick(id, idFormato) {
        var intExhibicionCodigo = id.substring(3);
        var accion = id.substring(0, 3);
        
        window.location = 'RentaEspaciosDetalle.aspx?intExhibicionCodigo=' + intExhibicionCodigo;
    }

    function fnImplementado() {

        if (document.getElementById('chkImplementado').checked == true) {

            document.getElementById('cboMotivo').selectedIndex = 0
            document.getElementById('cboMotivo').disabled = true;
            document.getElementById('txtRazon').value = '';
            
        }
        else {
            document.getElementById('cboMotivo').disabled = false;
        }
    }

    function fnDetalle_onclick(intExhibicionCodigo) {

        //Se guarda el id del registro seleccionado por el usuario
        document.getElementById('hdnCodigoId').value = intExhibicionCodigo;
        
        //Se muestra la tabla con la informacion del detalle
        document.getElementById('tblDetalle').style.display = 'block';

        
        //Recibe el id, muestra su detalle en los campos y los muestra al usuario
        document.forms[0].action = '<%=strThisPageName%>?strCmd=cmdDetalleExhibicion&intExhibicionCodigo=' + intExhibicionCodigo;
        document.forms[0].target = "ifrOculto";
        document.forms[0].submit();
    }
       
    //-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmConsultaRentaEspacios" onSubmit="return frmConsultaRentaEspacios_onsubmit()">
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
                    Exhibiciones Adicionales - Consulta
                </span>
                <br /> 
                 <table  width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="tdtittablas"><div id="tblResultados"></div></td>
                    </tr>
                 </table>
                <br />
                <!--<div id="divDetalle" width="100%">-->
                 <table id="tblDetalle" width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="35%" align="center"><!--src="<= strRutaImagen()%>"-->
                            <img id="imgDetalle" src="<%= strRutaImagen()%>" border="0" style="margin:10px; border:1px solid #ccc; width:120px; height:170px;" >
                        </td>
                        <td width="65%">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="tdtittablas">Plan de salida:</td>
                                                <td id="tdPlanSalida" class="tdconttablas"></td>
                                            </tr>
                                            <tr>
                                                <td class="tdtittablas">Fecha Fin:</td>
                                                <td id="tdFechaFin" class="tdconttablas"></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td><br />
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="txsubtitulo" colspan="2">Estatus</td>
                                            </tr>
                                            <tr>
                                                <td class="tdtittablas" colspan="2">
                                                    Implementado:<input type="checkbox" id="chkImplementado" name="chkImplementado" onclick='javascript: fnImplementado()'/>
                                                </td>
                                            </tr>
                                            <tr id="trMotivo">
                                                <td class="tdtittablas">Si no se implementó, indique el Motivo:</td>
                                    
                                            </tr>
                                            <tr>
                                                <td class="tdtittablas">
                                                    <select id="cboMotivo" name="cboMotivo" class="campotabla">
                                                        <option selected value="0">Seleccione</option>
                                                    </select>
                                                </td>
                                                
                                            </tr>
                                            <tr id="idlblRazon">
                                                <td class="tdtittablas">Comentarios:</td>
                                    
                                            </tr>
                                            <tr >
                                                <td class="tdtittablas" id="idtxtRazon">
                                                        <input onKeyPress=" return txtRazon_onKeyPress(event);" id="txtRazon" class="campotabla"  name="txtRazon" maxLength="20"> 
                                                </td>
                                                <td>
                                                    <input name="cmdGuardar" type="button" class="boton" value="Guardar" onClick="return cmdGuardar_onclick()">
                                                    <input type="hidden" id="hdnCodigoId" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                   </table>
                <!--</div> de toda la tabla para mostrar u ocultar detalles del registro seleccionado-->
                <br> 
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
            <div id="divConsultaExhibicionesAdicionales">
                <%= Me.strTablaConsultaExhibicionesAdicionales()%>
            </div>
        <div id="divConsultaDetalle">
                <!--<= Me.strTablaConsultaDetalle()%>-->
            </div>            
        </div>
<script language="JavaScript">

    //Codigo para ponerle sombra al registro seleccionado por el usuario
    var id = '<%= strCodigoExhibicionId()%>';
        document.getElementById('hdnCodigoId').value = id;
        
        if (trim(id) != '') {
            //Cambia de color el registro seleccionado
            parent.document.getElementById('NombreExhibicion' + id).style.background = "#dddddd";
            parent.document.getElementById('TipoRenta' + id).style.background = "#dddddd";
            parent.document.getElementById('Proveedor' + id).style.background = "#dddddd";
            parent.document.getElementById('Categoria' + id).style.background = "#dddddd";
            parent.document.getElementById('Planograma' + id).style.background = "#dddddd";
            parent.document.getElementById('CatMan' + id).style.background = "#dddddd";
            parent.document.getElementById('FechaInicio' + id).style.background = "#dddddd";
            parent.document.getElementById('FechaFin' + id).style.background = "#dddddd";
            parent.document.getElementById('Estatus' + id).style.background = "#dddddd";
            parent.document.getElementById('Accion' + id).style.background = "#dddddd";
        }
</script>    
    <iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrPaginaenBlanco.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</html>
