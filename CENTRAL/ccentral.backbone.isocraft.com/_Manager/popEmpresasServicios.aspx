<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="popEmpresasServicios.aspx.vb" Inherits="com.isocraft.backbone.ccentral.popEmpresasServicio"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Benavides : popEmpresasServicios</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
		<link href="../static/css/estilo.css" rel="stylesheet">
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
  document.forms[0].action = "<%= strFormAction %>";
  return(true);
}

function strRecordBrowserHTML() {
  document.write("<%=strRecordBrowserHTML%>");
   return(true);
}
function cmdCerrar_onclick() {
  window.close();
  return(true);
}

function ClosePopup(intValor,strNombre)
{
	opener.document.forms[0].elements['<%=Request.QueryString("strEmpresaServicio")%>'].value = intValor;
	opener.document.forms[0].elements['<%=Request.QueryString("strEmpresaServicioNombreId")%>'].value = strNombre;
	opener.document.forms[0].elements['txtFormaPagoIndexOculto'].value = 4;

	<% if Request.QueryString("strEvalJs")<>"" then %>
	eval("<%=Request.QueryString("strEvalJs")%>");
	<% end if %>		
	
	<% if Request.QueryString("strEvalJsClosePopup")<>"" then %>
	eval("<%=Request.QueryString("strEvalJsClosePopup")%>");
	<% end if %>		
	
	self.close();
    return(true);
}

function window_onunload() {
	<% if Request.QueryString("strEvalJs")<>"" then %>
	eval("<%=Request.QueryString("strEvalJs")%>");
	<% end if %>
}

//-->
			</script>
	</HEAD>
	<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0"
		onUnload="return window_onunload()">
		<form name="frmPopArticulo" action="about:blank" method="post">
			<table height="158" cellspacing="0" cellpadding="0" width="100%" bgcolor="#ffffff" border="0">
				<tr>
					<td class="tdlogopop" colspan="2" height="21"><img height="54" src="../static/images/logo_pop.gif" width="177"></td>
				</tr>
				<tr>
					<td width="2%">&nbsp;</td>
					<td valign="top" width="99%" height="10">&nbsp;</td>
				</tr>
				<tr>
					<td width="2%">&nbsp;</td>
					<td valign="top" height="30"><span class="txtitulo">Catálogo Empresas</span><span class="txcontenido">Selecciona 
        la Empresa haciendo clic en el nombre.<br>
        <br>
        </span>
						<script language="javascript">strRecordBrowserHTML()</script>
						<span class="txcontenido"></span></td>
				</tr>
				<tr>
					<td width="2%">&nbsp;</td>
					<td><input name="cmdCerrar" type="submit" class="boton" id="cmdCerrar" value="Cerrar" onClick="return cmdCerrar_onclick()">
						<br>
						<br>
					</td>
				</tr>
			</table>
		</form>
		<%= strJavascriptWindowOnLoadCommands %>
	</body>
</HTML>
