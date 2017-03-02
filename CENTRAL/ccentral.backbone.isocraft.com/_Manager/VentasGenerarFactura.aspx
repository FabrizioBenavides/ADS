<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" enableViewState="False" Explicit="True" Trace="False" Strict="True" CodeBehind="VentasGenerarFactura.aspx.vb"     Inherits="com.isocraft.backbone.ccentral.VentasGenerarFactura" codePage="28592"  %>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
		<link href="css/estilo.css" rel="stylesheet" type="text/css">
			<script language="javascript" id="clientEventHandlersJS">
<!--

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}

function window_onload() {
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
	document.forms[0].action = "<%=strFormAction%>";
	
	document.frmVentasGenerarFactura.cmdCerrar.disabled=false;   	
			  
	<%=strJavascriptWindowOnLoadCommands%>
}

function fnOnError(mensaje) 
{ 
   if (mensaje.substring(1,16)=="opener.document") 
   { 
       window.close();	 
       return true; 
   } 
   return true; 
} 

function cmdCerrar_onclick() {	
   window.onerror=fnOnError; 
   
   opener.document.forms[0].elements['cmdConsultar'].onclick();
   window.close();	
   return(true);	
}

function cmdGenerar_onclick() {
   document.frmVentasGenerarFactura.cmdGenerar.disabled=true;
   document.frmVentasGenerarFactura.cmdCerrar.disabled=true;
   
   document.frmVentasGenerarFactura.strGenerando.value="***** GENERANDO FACTURAS DIARIAS DEL MES *****";
         
   document.forms[0].action = 'VentasGenerarFactura.aspx?strCmd=Generar&intMesVenta=' + <%=intMesVenta%>;
   document.forms[0].submit();    
}

//-->
			</script>
	</HEAD>
	<body leftmargin="0" topmargin="0" marginheight="0" marginwidth="0" onLoad="return window_onload()">
		<form name="frmVentasGenerarFactura" action="about:blank" method="post">
			<table height="158" cellspacing="0" cellpadding="0" width="760" bgcolor="#ffffff" border="0">
				<tr>
					<td class="tdlogopop" colspan="3" height="21">
						<img height="54" src="../static/images/logo_pop.gif" width="177"></td>
				</tr>
				<tr>
					<td valign="top" width="100%" height="10" colspan="3">&nbsp;</td>
				</tr>
				<tr>
					<td width="2%">&nbsp;</td>
					<td valign="top" width="96%">
						<span class='txsubtitulo'><img src='../static/images/bullet_subtitulos.gif' width='17' height='11' align='absMiddle'>Datos 
        de Expedición</span>
						<table class="tdEnvolventeTablaAzul" width="100%" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td class="RBTdAzul" width="12%">CALLE</td>
								<td class="RBTdAzul" width="40%"><%=strExpedicionCalle%></td>
								<td class="RBTdAzul" width="4%">&nbsp;</td>
								<td class="RBTdAzul" width="8%">CP</td>
								<td class="RBTdAzul" width="36%"><%=strExpedicionCodigoPostal%></td>
							</tr>
							<tr>
								<td class="RBTdAzul" width="12%">No EXTERIOR</td>
								<td class="RBTdAzul" width="40%"><%=strExpedicionNoExterior%></td>
								<td class="RBTdAzul" width="4%">&nbsp;</td>
								<td class="RBTdAzul" width="8%">CIUDAD</td>
								<td class="RBTdAzul" width="36%"><%=strExpedicionCiudad%></td>
							</tr>
							<tr>
								<td class="RBTdAzul" width="12%">No INTERIOR</td>
								<td class="RBTdAzul" width="40%"><%=strExpedicionNoInterior%></td>
								<td class="RBTdAzul" width="4%">&nbsp;</td>
								<td class="RBTdAzul" width="8%">ESTADO</td>
								<td class="RBTdAzul" width="36%"><%=strExpedicionEstado%></td>
							</tr>
							<tr>
								<td class="RBTdAzul" width="12%">COLONIA</td>
								<td class="RBTdAzul" width="40%"><%=strExpedicionColonia%></td>
								<td class="RBTdAzul" width="4%">&nbsp;</td>
								<td class="RBTdAzul" width="8%">PAIS</td>
								<td class="RBTdAzul" width="36%"><%=strExpedicionPais%></td>
							</tr>
						</table>
						<br>
						<span class='txsubtitulo'><img src='../static/images/bullet_subtitulos.gif' width='17' height='11' align='absMiddle'>Datos 
        Cliente Fiscal</span>
						<table class="tdEnvolventeTablaAzul" width="100%" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td class="RBTdAzul" width="12%">RFC</td>
								<td class="RBTdAzul" width="80%" colspan="4"><%=strClienteFiscalRFC%>
									-
									<%=strClienteFiscalRazonSocial%>
								</td>
							</tr>
							<tr>
								<td class="RBTdAzul" width="12%">CALLE</td>
								<td class="RBTdAzul" width="40%"><%=strClienteFiscalCalle%></td>
								<td class="RBTdAzul" width="4%">&nbsp;</td>
								<td class="RBTdAzul" width="8%">CP</td>
								<td class="RBTdAzul" width="36%"><%=strClienteFiscalCodigoPostal%></td>
							</tr>
							<tr>
								<td class="RBTdAzul" width="12%">No EXTERIOR</td>
								<td class="RBTdAzul" width="40%"><%=strClienteFiscalNoExterior%></td>
								<td class="RBTdAzul" width="4%">&nbsp;</td>
								<td class="RBTdAzul" width="8%">CIUDAD</td>
								<td class="RBTdAzul" width="36%"><%=strClienteFiscalCiudad%></td>
							</tr>
							<tr>
								<td class="RBTdAzul" width="12%">No INTERIOR</td>
								<td class="RBTdAzul" width="40%"><%=strClienteFiscalNoInterior%></td>
								<td class="RBTdAzul" width="4%">&nbsp;</td>
								<td class="RBTdAzul" width="8%">ESTADO</td>
								<td class="RBTdAzul" width="36%"><%=strClienteFiscalEstado%></td>
							</tr>
							<tr>
								<td class="RBTdAzul" width="12%">COLONIA</td>
								<td class="RBTdAzul" width="40%"><%=strClienteFiscalColonia%></td>
								<td class="RBTdAzul" width="4%">&nbsp;</td>
								<td class="RBTdAzul" width="8%">PAIS</td>
								<td class="RBTdAzul" width="36%"><%=strClienteFiscalPais%></td>
							</tr>
						</table>
						<br>
						<span class='txsubtitulo'><img src='../static/images/bullet_subtitulos.gif' width='17' height='11' align='absMiddle'>Totales</span>
						<table width='100%' class='tdEnvolventeTablaGris' cellspacing='0' cellpadding='0' border='0'>
							<tr class='RBTitulos'>
								<td width='5%' class='rayita' valign='middle'>Mes:</td>
								<td width='25%' class='rayita' valign='middle' align='left'><%=strMesConsulta%></td>
								<td width='20%' class='rayita' valign='middle'>Sucursales Incluidas:</td>
								<td width='10%' class='rayita' valign='middle' align='left'><%= intSucursalesIncluidas%></td>
								<td width='15%' class='rayita' valign='middle'>Fecha Expedición:</td>
								<td width='20%' class='rayita' valign='middle' align='left'><%=strFechaExpedicion%></td>
							</tr>
						</table>
						<br>
						<table width='100%' class='tdEnvolventeTablaGris' cellspacing='0' cellpadding='0' border='0'>
							<tr class='RBTitulos'>
								<th class='rayita' align='left' valign='top'>
									&nbsp;
								</th>
								<th class='rayita' align='right' valign='top'>
									SubTotal</th>
								<th class='rayita' align='right' valign='top'>
									Importe Impuesto</th>
								<th class='rayita' align='right' valign='top'>
									Total</th>
							</tr>
							<tr>
								<td class='RBTdBlanco' align='right' valign='top'>Tasa 0</td>
								<td class='RBTdBlanco' align='right' valign='top'>---</td>
								<td class='RBTdBlanco' align='right' valign='top'>---</td>
								<td class='RBTdBlanco' align='right' valign='top'><%= fltTotalExcento%></td>
							</tr>
							<tr>
								<td class='RBTdAzul' align='right' valign='top'>Tasa 11</td>
								<td class='RBTdAzul' align='right' valign='top'><%=fltSubTotalTasa10%></td>
								<td class='RBTdAzul' align='right' valign='top'><%=fltImporteImpuestoTasa10%></td>
								<td class='RBTdAzul' align='right' valign='top'><%=fltTotalTasa10%></td>
							</tr>
							<tr>
								<td class='RBTdBlanco' align='right' valign='top'>Tasa 16</td>
								<td class='RBTdBlanco' align='right' valign='top'><%=fltSubTotalTasa15%></td>
								<td class='RBTdBlanco' align='right' valign='top'><%=fltImporteImpuestoTasa15%></td>
								<td class='RBTdBlanco' align='right' valign='top'><%=fltTotalTasa15%></td>
							</tr>
							<tr>
								<td class='RBTdAzul' align='right' colspan='4'><%=fltTotalSucursales%></td>
							</tr>
						</table>
					</td>
					<td width="2%">&nbsp;</td>
				</tr>
				<tr>
					<td width="2%">&nbsp;</td>
					<td><br>
						<input name="cmdCerrar" type="button" class="boton" id="cmdCerrar" value="Cerrar" onclick="return cmdCerrar_onclick()">
						&nbsp; <input name="cmdGenerar" type="button" class="boton" id="cmdGenerar" value="Generar" onclick="return cmdGenerar_onclick()">
					</td>
					<td width="2%">&nbsp;</td>
				</tr>
				<tr>
					<td width="2%">&nbsp;</td>
					<td class="RBTdAzul" width="80%" align="center"><input type="text" readonly name="strGenerando" class="campotablaresultadoenvolventeazul"
							size="50"></td>
					<td width="2%">&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
