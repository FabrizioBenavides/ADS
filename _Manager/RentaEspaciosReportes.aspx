<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RentaEspaciosReportes.aspx.vb" Inherits="com.isocraft.backbone.ccentral.RentaEspaciosReportes" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html>
<head>
    <title>Benavides: Exhibiciones Adicionales</title>
        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link href="css/menu.css" rel="stylesheet" type="text/css">
		<link href="css/estilo.css" rel="stylesheet" type="text/css">
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
    window.close();
}

function cmdImprimir_onclick(CodigoId, idFormato) {

    if (document.getElementById('tblResultados').innerHTML == '') {

        alert('Realice la consulta por favor');
        return (false);
    }

    var confirmar = confirm('Desea imprimir la información?');
    if (confirmar == true) {

        var strCmd = '<%= strCmd()%>'
        var strParametros ='';
        strParametros = '';
        strParametros = '?strDivisionArticulosId=' + document.getElementById('hdnDivisionArticulosId').value;
        strParametros = strParametros + '&strCategoriaOperativaId=' + document.getElementById('hdnCategoriaOperativaId').value;
        strParametros = strParametros + '&strCatmanId=' + document.getElementById('hdnCatmanId').value;
        strParametros = strParametros + '&strProveedorId=' + document.getElementById('hdnProveedorId').value;
        strParametros = strParametros + '&strSocioComercial=' + document.getElementById('hdnSocioComercial').value;
        strParametros = strParametros + '&strTipoExhibicionId=' + document.getElementById('hdnTipoExhibicionId').value;
        strParametros = strParametros + '&strTipoRentaId=' + document.getElementById('hdnTipoMuebleId').value;
        strParametros = strParametros + '&strTipoEspacioPublicitarioId=' + document.getElementById('hdnTipoEspacioPublicitarioId').value;
        strParametros = strParametros + '&strPlanogramaCapturadoId=' + document.getElementById('hdnPlanogramaCapturadoId').value;
        strParametros = strParametros + '&strNombreExhibicion=' + document.getElementById('hdnNombreExhibicion').value;
        strParametros = strParametros + '&strPlanSalidaId=' + document.getElementById('hdnPlanSalidaId').value;
        strParametros = strParametros + '&strCmdImprimir=' + strCmd;

        document.forms[0].action = '<%= strThisPageName%>' + strParametros;
        document.forms[0].target = "ifrOculto";
        document.forms[0].submit();

        return (true);
    }
}

		    function fnImprimir(strPromocioneAvanzada) {

		        //Llamada desde el servidor para imprimir resultados de las consulta.
		        document.ifrPageToPrint.document.all.divBody.innerHTML = strPromocioneAvanzada;
		        document.ifrPageToPrint.focus();
		        window.print();
		    }

		    function doSubmit(c, t, p) {

		        var strCmd = '<%= strCmd()%>'
		        var strParametros = '';
		        strParametros = '';
		        strParametros = '?strDivisionArticulosId=' + document.getElementById('hdnDivisionArticulosId').value;
		        strParametros = strParametros + '&strCategoriaOperativaId=' + document.getElementById('hdnCategoriaOperativaId').value;
		        strParametros = strParametros + '&strCatmanId=' + document.getElementById('hdnCatmanId').value;
		        strParametros = strParametros + '&strProveedorId=' + document.getElementById('hdnProveedorId').value;
		        strParametros = strParametros + '&strSocioComercial=' + document.getElementById('hdnSocioComercial').value;
		        strParametros = strParametros + '&strTipoExhibicionId=' + document.getElementById('hdnTipoExhibicionId').value;
		        strParametros = strParametros + '&strTipoRentaId=' + document.getElementById('hdnTipoMuebleId').value;
		        strParametros = strParametros + '&strTipoEspacioPublicitarioId=' + document.getElementById('hdnTipoEspacioPublicitarioId').value;
		        strParametros = strParametros + '&strPlanogramaCapturadoId=' + document.getElementById('hdnPlanogramaCapturadoId').value;
		        strParametros = strParametros + '&strNombreExhibicion=' + document.getElementById('hdnNombreExhibicion').value;
		        strParametros = strParametros + '&strPlanSalidaId=' + document.getElementById('hdnPlanSalidaId').value;
		        strParametros = strParametros + '&strCmd=' + strCmd;

		        if (p == null) {
		            p = document.getElementById('txtCurrentPage').value;
		        }
		        else {
		            document.getElementById('txtCurrentPage').value = p;
		        }
		        document.forms[0].action =
                '<%= strThisPageName%>' + strParametros + '&pager=true&p=' + p;
                document.forms[0].target = "ifrOculto";
                document.forms[0].submit();
		    }

		    function cmdExportar_onclick() {

		        if (document.getElementById('tblResultados').innerHTML == '') {

		            alert('Realice la consulta por favor');
		            return (false);
		        }

		        var confirmar = confirm('Desea exportar la informacion a Excel?');
		        if (confirmar == true) {

		            var strCmd = '<%= strCmd()%>'
		            var strParametros = '';
		            strParametros = '';
		            strParametros = '?strDivisionArticulosId=' + document.getElementById('hdnDivisionArticulosId').value;
		            strParametros = strParametros + '&strCategoriaOperativaId=' + document.getElementById('hdnCategoriaOperativaId').value;
		            strParametros = strParametros + '&strCatmanId=' + document.getElementById('hdnCatmanId').value;
		            strParametros = strParametros + '&strProveedorId=' + document.getElementById('hdnProveedorId').value;
		            strParametros = strParametros + '&strSocioComercial=' + document.getElementById('hdnSocioComercial').value;
		            strParametros = strParametros + '&strTipoExhibicionId=' + document.getElementById('hdnTipoExhibicionId').value;
		            strParametros = strParametros + '&strTipoRentaId=' + document.getElementById('hdnTipoMuebleId').value;
		            strParametros = strParametros + '&strTipoEspacioPublicitarioId=' + document.getElementById('hdnTipoEspacioPublicitarioId').value;
		            strParametros = strParametros + '&strPlanogramaCapturadoId=' + document.getElementById('hdnPlanogramaCapturadoId').value;
		            strParametros = strParametros + '&strNombreExhibicion=' + document.getElementById('hdnNombreExhibicion').value;
		            strParametros = strParametros + '&strPlanSalidaId=' + document.getElementById('hdnPlanSalidaId').value;
		            strParametros = strParametros + '&strCmdExportar=' + strCmd;

		            document.forms[0].action = '<%= strThisPageName%>' + strParametros;
                    document.forms[0].target = "ifrOculto";
                    document.forms[0].submit();

                    return (true);
                }
            }

//-->
		</script>
	</HEAD>
	<body language="javascript" onload="return window_onload()">
		<form name="frmMain" action="about:blank" method="post" runat="server" ID="Form2">
			<table style="width:780px;" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td class="tdtab">Está en : <a href="../_Manager/SucursalHome.aspx">Central</a> : Exhibiciones Adicionales
					</td>
				</tr>
			</table>
			<table style="width:780px;" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="tdgeneralcontent">
						<table style="width:750px;" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td>
								    <div id="tblResultados" style="width:100%"></div>
								</td>
							</tr>
							<tr style="text-align:right">
								<td class="tdpadleft5" >
                                    <input style="margin:20px;" class="button" id="cmdRegresar" onclick="return cmdCancelar_onclick()" type="button" value="Regresar" name="cmdRegresar">
                                    <input id="cmdImprimir" name="cmdImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick()" style="margin:20px;">
                                    <input name="cmdExportar" type="button" class="boton" value="Exportar" onClick="return cmdExportar_onclick()" style="margin:20px;">
                                
                                    <input type="hidden" id="hdnDivisionArticulosId" name="hdnDivisionArticulosId" value="<%= strDivisionArticulosId()%>"/>
                                    <input type="hidden" id="hdnCategoriaOperativaId" name="hdnCategoriaOperativaId" value="<%= strCategoriaOperativaId()%>"/>
                                    <input type="hidden" id="hdnCatmanId" name="hdnCatmanId" value="<%= strCatmanId()%>"/>
                                    <input type="hidden" id="hdnProveedorId" name="hdnProveedorId" value="<%= strProveedorId()%>"/>
                                    <input type="hidden" id="hdnSocioComercial" name="hdnSocioComercial" value="<%= strSocioComercial()%>"/>
                                    <input type="hidden" id="hdnTipoExhibicionId" name="hdnTipoExhibicionId" value="<%= strTipoExhibicionId()%>"/>
                                    <input type="hidden" id="hdnTipoMuebleId" name="hdnTipoMuebleId" value="<%= strTipoRentaId()%>"/>
                                    <input type="hidden" id="hdnTipoEspacioPublicitarioId" name="hdnTipoEspacioPublicitarioId" value="<%= strTipoEspacioPublicitarioId()%>"/>
                                    <input type="hidden" id="hdnPlanogramaCapturadoId" name="hdnPlanogramaCapturadoId" value="<%= strPlanogramaCapturadoId()%>"/>
                                    <input type="hidden" id="hdnNombreExhibicion" name="hdnNombreExhibicion" value="<%= strNombreExhibicion()%>"/>
                                    <input type="hidden" id="hdnPlanSalidaId" name="hdnPlanSalidaId" value="<%= strPlanSalidaId()%>"/>
                                    <input type="hidden" id="hdnFechaInicio" name="hdnFechaInicio" value="<%= dtmFechaInicio()%>"/>
                                    <input type="hidden" id="hdnFechaFin" name="hdnFechaFin" value="<%= dtmFechaFin()%>"/>
                                </td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table style="width:780px;"  border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaFooterCentral()</script></td>
				</tr>
			</table>
		</form>
        <div style="display:none;"> 
  <div id="divConsultaReporte"> 
      <%= Me.strTablaConsultaReporte()%> 
  </div>
</div>
        <script language="javascript">
            if (document.getElementById('tblResultados').innerHTML == '') {
                document.getElementById('cmdImprimir').style.display = 'none';
                document.getElementById('cmdExportar').style.display = 'none';
            }
        </script>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
<iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>

	</body>
</HTML>
