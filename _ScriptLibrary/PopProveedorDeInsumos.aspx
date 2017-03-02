
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PopProveedorDeInsumos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.PopProveedorDeInsumos" %>

<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<% 
'====================================================================
' Page          : PopProveedorDeInsumos.aspx
' Title         : Administracion POS y BackOffice
' Description   : Consulta y seleccion de proveedor de Insumos
' Copyright     : 2014
' Company       : Deintec
' Author        : Carlos Vazquez
' Version       : 1.0
' Last Modified : Lunes, 08 de Agosto, 2014 
'                 
'====================================================================	
%>
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--
    var blnSinSeleccion = true;

    function window_onload() {
        document.forms[0].action = "<%=strFormAction%>";
            return (true);
    }

    function strRecordBrowserHTML() {
        document.write("<%=strRecordBrowserHTML%>");
        return (true);
    }

    function cmdCerrar_onclick() {
        //ClosePopup(0, "", "", "", "", "", "", "");

        ClosePopup(0, "", "", "", "", "");
    }

    function ClosePopup(intProveedorId, strProveedorNombreId, strProveedorRazonSocial, strProveedorRFC, blnCapturaCosto, fltMargenFactura) {
        
        var strCampoDestino = "";

        strCampoDestino = '<%=Request.QueryString("campoProveedorId")%>';
        if (strCampoDestino.length > 0) {
            opener.document.forms[0].elements[strCampoDestino].value = intProveedorId;
        }

       strCampoDestino = '<%=Request.QueryString("campoProveedorNombreId")%>';
       if (strCampoDestino.length > 0) {
           opener.document.forms[0].elements[strCampoDestino].value = strProveedorNombreId;
       }

       strCampoDestino = '<%=Request.QueryString("campoProveedorRazonSocial")%>';
       if (strCampoDestino.length > 0) {
           opener.document.forms[0].elements[strCampoDestino].value = strProveedorRazonSocial;
       }

       strCampoDestino = '<%=Request.QueryString("campoProveedorRFC")%>';
       if (strCampoDestino.length > 0) {
           opener.document.forms[0].elements[strCampoDestino].value = strEliminaGuiones(strProveedorRFC);
       }

       strCampoDestino = '<%=Request.QueryString("campoCapturaCosto")%>';
       if (strCampoDestino.length > 0) {
           opener.document.forms[0].elements[strCampoDestino].value = blnCapturaCosto;
       }

       strCampoDestino = '<%=Request.QueryString("campoMargenFactura")%>';
       if (strCampoDestino.length > 0) {
           opener.document.forms[0].elements[strCampoDestino].value = fltMargenFactura;
       }


   <% if Request.QueryString("strEvalJs") <> "" then %>
    eval("<%=Request.QueryString("strEvalJs")%>");
   <% end if %>

    blnSinSeleccion = false;
    self.close();
}

function window_onunload() {
    if (blnSinSeleccion) {
        //ClosePopup(0, "", "", "", "", "", "", "", "", 0);
        ClosePopup(0, "", "", "", "", "");
    }
}

// Funcion donde Eliminamos los guiones de alguna cadena.
function strEliminaGuiones(objCampo) {
    var strInicial, strFinal, strResultado;

    strInicial = objCampo;
    strFinal = strInicial.split("-");

    strResultado = '';
    for (intContador = 0; intContador < strFinal.length; intContador++) {
        strResultado = strResultado + strFinal[intContador];
    }

    return (strResultado);
}


//-->
			</script>
</HEAD>
<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0" onunload="return window_onunload()">
<form name="frmPopProveedorInsumosMateriaPrima" action="about:blank" method="post">
  <table height="158" cellspacing="0" cellpadding="0" width="100%" bgcolor="#ffffff" border="0">
    <tr> 
      <td class="tdlogopop" colspan="2" height="54"><script language="javascript">crearTablaHeaderPop()</script></td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td valign="top" width="99%" height="10">&nbsp;</td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td valign="top" height="30"><span class="txtitulo">Proveedores</span><span class="txcontenido">Selecciona 
        el Proveedor haciendo clic en el nombre.<br>
        <br>
        </span> <script language="javascript">strRecordBrowserHTML()</script> 
        <span class="txcontenido"></span></td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td><input name="cmdCerrar" type="submit" class="boton" id="cmdCerrar" value="Cerrar" onclick="return cmdCerrar_onclick()"> 
        <br> <br> </td>
    </tr>
  </table>
</form>
</body>
</HTML>
