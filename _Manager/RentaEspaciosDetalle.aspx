<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="RentaEspaciosDetalle.aspx.vb" Inherits="com.isocraft.backbone.ccentral.RentaEspaciosDetalle" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>

<HTML>
<HEAD>
<title>Benavides: Exhibiciones Adicionales - Consulta</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/tools.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/calendario.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/cal_format00.js"></script>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<LINK rel="stylesheet" type="text/css" href="css/menu.css">
<LINK rel="stylesheet" type="text/css" href="css/estilo.css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script id="clientEventHandlersJS" language="javascript">

<!--
    strUsuarioNombre = "<%= strUsuarioNombre %>";
    strFechaHora = "<%= strHTMLFechaHora %>";

    function window_onload() {
        document.forms[0].action = "<%= strFormAction %>";
    }

    function cmdCancelar_onclick() {
        window.location.href = "RentaEspaciosConsulta.aspx";
    }

function trim(stringToTrim) {
    return stringToTrim.replace(/^\s+|\s+$/g, "");
}

function doSubmit(c, t, p) {
    if (p == null) {
        p = document.getElementById('txtCurrentPage').value;
    }
    else {
        document.getElementById('txtCurrentPage').value = p;
    }
    document.forms[0].action =
        '<%= strThisPageName%>?strCmd=cmdConsultar&pager=true&p=' + p + '&intExhibicionCodigo=' + document.getElementById("hdnCodigoId").value;
    document.forms[0].target = "ifrOculto";
    document.forms[0].submit();
}

function cmdImprimir_onclick(CodigoId, idFormato) {

    var intExhibicionCodigo = document.getElementById("hdnCodigoId").value;

    document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdImprimir&intExhibicionCodigo=' + intExhibicionCodigo;
    document.forms[0].target = "ifrOculto";
    document.forms[0].submit();

    return (true);
}

function fnImprimir(strPromocioneAvanzada) {

    //Llamada desde el servidor para imprimir resultados de las consulta.
    document.ifrPageToPrint.document.all.divBody.innerHTML = strPromocioneAvanzada;
    document.ifrPageToPrint.focus();
    window.print();
}

function cmdRegresar_onclick() {
    //Ir a la página de Consulta de Renta de Espacios en Sucursal.
    window.location = "RentaEspaciosConsulta.aspx";
}

//-->
		</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onload="return window_onload()">
<form id="frmDetalleRentaEspacios" method="post" name="frmDetalleRentaEspacios" action="about:blank" onSubmit="return frmDetalleRentaEspacios_onsubmit()">
  <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
    <tr> 
      <td> <script language="JavaScript">crearTablaHeader()</script> </td>
    </tr>
  </table>
  <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
    <tr> 
      <td width="10">&nbsp;</td>
      <td class="tdtab" width="770">Está en : <A href="../_Manager/InicioHome.aspx">Central</A> 
        : Exhibiciones Adicionales </td>
    </tr>
  </table>
    <br />
  <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
      <tr>
          <td width="10">&nbsp;</td>
          <td colspan="4">
              <h1>Exhibiciones Adicionales - Detalle</h1>
          </td>
      </tr>
      <tr>
          <td width="10">&nbsp;</td>
          <td> 
              <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
                  <tr>
                      <td colspan="2">
                          <h2>Datos Generales:</h2>
                      </td>
                  </tr>
                  <tr> 
                    <td class="tdtexttablebold" width="150px">División:</td>
                    <td class="tdconttablas" width="240px"><%= strDivision()%></td>
                    <td class="tdtexttablebold" width="150px">Categoría:</td>
                    <td class="tdconttablas" width="240px"><%= strCategoria()%></td>
                    
                </tr>
                <tr>
                    <td class="tdtexttablebold" width="150px">CATMAN:</td>
                    <td class="tdconttablas" width="240px"><%= strCatman()%></td>
                    <td class="tdtexttablebold" width="150px">Socio comercial:</td>
                    <td class="tdconttablas" width="240px"><%= strSocioComercial()%></td>
                </tr>
                  <tr>
                      <td class="tdtexttablebold" width="150px">Proveedor:</td>
                    <td class="tdconttablas" colspan="3"><%= strProveedor()%></td>
                  </tr>
              </table>
             </td>
          </tr>
          <tr>
              <td width="10">&nbsp;</td>
              <td>
                  <br />
                  <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
                      <tr>
                        <td colspan="2">
                            <h2>Datos Exhibición:</h2>
                        </td>
                      </tr>
                      <tr>
                          <td class="tdtexttablebold" width="150px">Tipo de Renta:</td>
                          <td class="tdconttablas" width="240px"><%= strTipoRenta()%></td>
                          <td class="tdtexttablebold" width="150px">Tipo de Exhibición:</td>
                          <td class="tdconttablas" width="240px"><%= strTipoExhibicion()%></td>
                          
                      </tr>
                      <tr>
                          <td class="tdtexttablebold" width="150px">Espacio Publicitario:</td>
                          <td class="tdconttablas" width="240px"><%= strEspacioPublicitario()%></td>
                          <td class="tdtexttablebold" width="150px">Nombre de la exhibición:</td>
                          <td class="tdconttablas" width="240px"><%= strNombreExhibicion()%></td>
                      </tr>
                      <tr>
                          <td class="tdtexttablebold" width="150px">Plan de salida:</td>
                          <td class="tdconttablas" width="240px"><%= strPlanSalida()%></td>
                          <td class="tdtexttablebold" width="150px">Comentarios:</td>
                          <td class="tdconttablas" width="240px"><%= strComentarios()%></td>
                      </tr>
                      <tr>
                          <td class="tdtexttablebold" width="150px">Tipo de Planograma:</td>
                          <td class="tdconttablas" width="240px"><%= strTipoPlanograma()%></td>
                          <td class="tdtexttablebold">Planograma:</td>
                          <td class="tdconttablas" width="240px"><%= strPlanograma()%></td>
                      </tr>
                      <tr>
                          <td class="tdtexttablebold" width="150px">Estatus:</td>
                          <td class="tdconttablas" width="240px"><%= strEstatus()%></td>
                      </tr>
            </table>
        </td>
      </tr>
      <tr>
          <td width="10">&nbsp;</td>
          <td>
             <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
                 <tr>
                     <td width="390px"><br /><h2>Costos e Ingresos:</h2>
                         <table border="0" cellSpacing="0" cellPadding="0" style="width:390px;">
                             <tr>
                                 <td class="tdtexttablebold" width="150px">Costo Merch:</td>
                                 <td class="tdconttablas" width="240px">$<%= strCostoMerch()%></td>
                             </tr>
                             <tr>
                                 <td class="tdtexttablebold" width="150px">Costo Catman:</td>
                                 <td class="tdconttablas" width="240px">$<%= strCostoCatman()%></td>
                             </tr>
                             <tr>
                                 <td class="tdtexttablebold" width="150px">Ingreso Total Merch:</td>
                                 <td class="tdconttablas" width="240px">$<%= strIngresoTotMerch()%></td>
                             </tr>
                             <tr>
                                 <td class="tdtexttablebold" width="150px">Ingreso Total Catman:</td>
                                 <td class="tdconttablas" width="240px">$<%= strIngresoTotCatMan()%></td>
                             </tr>
                             <tr>
                                 <td class="tdtexttablebold" width="150px">Ingreso Total:</td>
                                 <td class="tdconttablas" width="240px">$<%= strIngresoTotal()%></td>
                             </tr>
                         </table>
                     </td>
                     <td style="width:390px;" align="center">
                         <img id="imgDetalle" src="<%= strRutaImagen()%>" border="0" style="margin:10px; border:1px solid #ccc; width:150px; height:170px;" >
                     </td>
                 </tr>
                 <tr> 
                     <td colspan="2"><br />
                         <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
                             <tr>
                                <td colspan="2">
                                    <h2>Vigencia:</h2>
                                </td>
                            </tr>
                             <tr>
                                 <td class="tdtexttablebold" width="150px">Fecha inicio:</td>
                                 <td class="tdconttablas" width="240px"><%= strFechaInicio()%></td>
                                 <td class="tdtexttablebold" width="150px">Fecha fin:</td>
                                 <td class="tdconttablas" width="240px"><%= strFechaFin()%></td>
                             </tr>
                         </table>
                     </td>
                  </tr>
             </table>
             </table>
            </td>
          </tr>
      <tr>
          <td>
              <br />
    <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
        <tr>
            <td width="10">&nbsp;</td>
            <td>
                <table border="0" cellSpacing="0" cellPadding="0" width="780">
                    <tr>

                        <td><div id="tblSucursalesAsignadas" style="width:100%"></div></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
                     <td align="right" colspan="4">
                         <input id="cmdImprimir" name="cmdImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick()" style="margin-top:20px;">
                         <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()" style="margin-top:20px;">
                         <input type="hidden" id="hdnCodigoId" name="hdnCodigoId" value="<%= strCodigoId()%>"/>
                     </td>
                 </tr>
        </table>
        </td>
    </tr>
  </table>
    <br />
  <table border="0" cellSpacing="0" cellPadding="0" width="780">
      <tr> 
        <td> 
            <script language="JavaScript" type="text/javascript">crearTablaFooterCentral()</script> 
        </td>
      </tr>
  </table>
    <script language="JavaScript">
	<!--
    new menu(MENU_ITEMS, MENU_POS);
    //-->
  </script>
  </form>
<div style="display:none;"> 
    <div id="divConsultaSucursalesAsignadas"><%= Me.strTablaConsultaSucursalesAsignadas()%></div>
</div>
    
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
<iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</HTML>
