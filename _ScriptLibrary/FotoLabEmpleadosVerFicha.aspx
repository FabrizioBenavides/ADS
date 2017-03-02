<%@ Import Namespace="Benavides.PosAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FotoLabEmpleadosVerFicha.aspx.vb" Inherits="com.isocraft.backbone.ccentral.FotoLabEmpleadosVerFicha"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador de Puntos de Venta</title>
		<%  '====================================================================
    ' Page          : FotoLabEmpleadosVerFicha.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página donde se muestran los datos del empleado
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Jorge Tamez
    ' Version       : 1.0
    ' Last Modified : Viernes, Agosto 22, 2003
    '====================================================================
%>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
		<link rel="stylesheet" href="../static/css/estilo.css">
			<script language="JavaScript" src="../static/scripts/Tools.js"></script>
			<script id="clientEventHandlersJS" language="javascript">
<!--

var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";


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
 return(true);
}

function strCompaniaSucursal() {
   document.write(<%=intCompaniaId%>+" - "+<%=intSucursalId%>);
}

function strSucursalNombre(){
   document.write("<%=strSucursalNombre%>");
   return(true);
}

function strUsuarioNombre() {
   document.write("<%=strUsuarioNombre%>");
   return(true);
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}

function cmdImprimir_onclick() {
	printContent();
	return(true);
}

function cmdRegresar_onclick() {
	history.go(-1)
	return(true);
}

function intEmpleadoId(){
 document.write(<%=intEmpleadoId%>);
 return(true);
}

function strEmpleadoNombre(){
 document.write("<%=strEmpleadoNombre%>");
 return(true);
}

function strEmpleadoApellidoPaterno(){
 document.write("<%=strEmpleadoApellidoPaterno%>");
 return(true);
}

function strEmpleadoApellidoMaterno(){
 document.write("<%=strEmpleadoApellidoMaterno%>");
 return(true);
}

function strEmpleadoGenero(){
 document.write("<%=strEmpleadoGenero%>");
 return(true);
}

function strEmpleadoRFC(){
 document.write("<%=strEmpleadoRFC%>");
 return(true);
}

function strEmpleadoNumeroIMSS(){
 document.write("<%=strEmpleadoNumeroIMSS%>");
 return(true);
}

function strEmpleadoCalle(){
 document.write("<%=strEmpleadoCalle%>");
 return(true);
}

function strEmpleadoNumeroExterior(){
 document.write("<%=strEmpleadoNumeroExterior%>");
 return(true);
}

function strEmpleadoColonia(){
 document.write("<%=strEmpleadoColonia%>");
 return(true);
}

function strEmpleadoNumeroInterior(){
 document.write("<%=strEmpleadoNumeroInterior%>");
 return(true);
}

function strEmpleadoEstado(){
 document.write("<%=strEmpleadoEstado%>");
 return(true);
}

function strEmpleadoCodigoPostal(){
 document.write("<%=strEmpleadoCodigoPostal%>");
 return(true);
}

function strEmpleadoCiudad(){
 document.write("<%=strEmpleadoCiudad%>");
 return(true);
}

function intPuestoEmpleadoId(){
 document.write(<%=intPuestoEmpleadoId%>);
 return(true);
}

function strEmpleadoPuesto(){
 document.write("<%=strEmpleadoPuesto%>");
 return(true);
}
 
//-->
			</script>
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
		<form action="about:blank" method="post" name="frmFotoLabEmpleadosVerFicha">
			<table width="780" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td><div id="ToPrintTxtSucursal">
							<table width="780" border="0" cellpadding="0" cellspacing="0">
								<tr>
									<td width="78" class="tdnodesucursal"><script language="javascript">strCompaniaSucursal()</script>
									</td>
									<td width="522" class="tdnombresucursal"><script language="javascript">strSucursalNombre()</script>
									</td>
									<td width="170" class="tdbotonestop"><a href="javascript:cmdSalirImg_onclick()" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image1','','../static/images/bsalir_on.gif',1)"><img src="../static/images/bsalir_off.gif" alt="salir" name="Image1" width="65" height="19"
												border="0"></a><a href="#" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image2','','../static/images/bayuda_on.gif',1)"><img src="../static/images/bayuda_off.gif" alt="ayuda" name="Image2" width="65" height="19"
												border="0"></a></td>
								</tr>
							</table>
						</div>
					</td>
				</tr>
				<tr>
					<td><table width="780" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td width="520" rowspan="2" class="tdlogo"><img src="../static/images/logo.gif" width="255" height="51"></td>
								<td width="90" height="26">&nbsp;</td>
								<td width="170" class="tdnombreusuario"><script language="javascript">strUsuarioNombre()</script>
								</td>
							</tr>
							<tr>
								<td width="90" height="51" align="right" class="tdbusqueda">&nbsp;</td>
								<td width="170" valign="middle" class="tdbusquedacampo">&nbsp;
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="34"><img src="../static/images/pixel.gif" width="1" height="34"></td>
				</tr>
				<tr>
					<td><table width="780" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td width="10" bgcolor="#ffffff"><img src="../static/images/pixel.gif" width="10" height="8"></td>
								<td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Está 
                en :</span><span class="txdmigaja"> <a href="FotoLab.aspx" class="txdmigaja">Sucursal</a> 
                : <a href="FotoLab.aspx" class="txdmigaja">Empleados</a> 
                : <a href="FotoLabEmpleadosAdministrar.aspx" class="txdmigaja">Administrar a los empleados</a> : </span><span class="txdmigaja">Ficha informativa 
                de empleado</span></div>
								</td>
								<td width="187" class="tdfechahora"><div id="ToPrintTxtFecha">
										<script language="javascript">strGetCustomDateTime()</script>
									</div>
								</td>
							</tr>
							<tr>
								<td width="10">&nbsp;</td>
								<td width="583" valign="top"><table width="583" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td width="100%" colspan="3" valign="top" class="tdtablacont"><div id="ToPrintHtmContenido"><span class="txtitulo">Ficha 
                      informativa de empleado</span>
													<table width="100%" border="0" cellpadding="0" cellspacing="0">
														<tr>
															<td width="486" align="right" class="tdtittablas">No. de empleado:</td>
															<td width="82" align="right" valign="middle" class="tdconttablas"><script language="JavaScript">intEmpleadoId()</script>
															</td>
														</tr>
													</table>
													<span class="txsubtitulo">Datos personales</span>
													<table width="100%" border="0" cellpadding="0" cellspacing="0">
														<tr>
															<td width="83" class="tdtittablas">Nombre:</td>
															<td valign="middle" class="tdconttablas"><script language="JavaScript">strEmpleadoNombre()</script>
																&nbsp;
																<script language="JavaScript">strEmpleadoApellidoPaterno()</script>
																&nbsp;
																<script language="JavaScript">strEmpleadoApellidoMaterno()</script>
															</td>
														</tr>
														<tr>
															<td class="tdtittablas">Sexo:</td>
															<td width="485" valign="middle" class="tdconttablas"><script language="JavaScript">strEmpleadoGenero()</script>
															</td>
														</tr>
														<tr>
															<td class="tdtittablas">RFC:</td>
															<td valign="middle" class="tdconttablas"><script language="JavaScript">strEmpleadoRFC()</script>
															</td>
														</tr>
														<tr>
															<td class="tdtittablas">IMSS:</td>
															<td valign="middle" class="tdconttablas"><script language="JavaScript">strEmpleadoNumeroIMSS()</script>
															</td>
														</tr>
													</table>
													<span class="txsubtitulo"><br>
                      <br>
                      Domicilio</span>
													<table width="100%" border="0" cellpadding="0" cellspacing="0">
														<tr>
															<td width="83" class="tdtittablas">Calle:</td>
															<td width="298" valign="middle" class="tdconttablas"><script language="JavaScript">strEmpleadoCalle()</script>
															</td>
															<td width="95" valign="middle" class="tdtittablas">No. exterior:</td>
															<td width="92" valign="middle" class="tdconttablas"><script language="JavaScript">strEmpleadoNumeroExterior()</script>
															</td>
														</tr>
														<tr>
															<td class="tdtittablas">Colonia:</td>
															<td valign="middle" class="tdconttablas"><script language="JavaScript">strEmpleadoColonia()</script>
															</td>
															<td valign="middle" class="tdtittablas">No. interior:</td>
															<td valign="middle" class="tdconttablas"><script language="JavaScript">strEmpleadoNumeroInterior()</script>
															</td>
														</tr>
														<tr>
															<td class="tdtittablas">Estado:</td>
															<td valign="middle" class="tdconttablas"><script language="JavaScript">strEmpleadoEstado()</script>
															</td>
															<td valign="middle" class="tdtittablas">C.P.</td>
															<td valign="middle" class="tdconttablas"><script language="JavaScript">strEmpleadoCodigoPostal()</script>
															</td>
														</tr>
														<tr>
															<td class="tdtittablas">Ciudad:</td>
															<td valign="middle" class="tdconttablas"><script language="JavaScript">strEmpleadoCiudad()</script>
															</td>
															<td valign="middle" class="tdtittablas">&nbsp;</td>
															<td valign="middle" class="tdpadleft5">&nbsp;</td>
														</tr>
													</table>
													<span class="txsubtitulo"><br>
                      <br>
                      Datos Laborales</span>
													<table width="100%" border="0" cellpadding="0" cellspacing="0">
														<tr>
															<td width="82" class="tdtittablas">Puesto:</td>
															<td width="486" valign="middle" class="tdconttablas"><script language="JavaScript">intPuestoEmpleadoId()</script>
																&nbsp; -&nbsp;
																<script language="JavaScript">strEmpleadoPuesto()</script>
															</td>
														</tr>
													</table>
												</div>
												<!--Aqui cerramos el content Div-->
												<br>
												<br>
												<input name="cmdRegresar" type="button" class="boton" id="cmdRegresar" value="Regresar"
													onClick="return cmdRegresar_onclick()"> &nbsp;&nbsp; <input name="cmdImprimir" type="button" class="boton" id="cmdImprimir" value="Imprimir"
													onClick="return cmdImprimir_onclick()"> &nbsp;&nbsp;
												<br>
												<br>
											</td>
										</tr>
									</table>
								</td>
								<td width="187" rowspan="2" valign="top" class="tdcolumnader">
									&nbsp;
								</td>
							</tr>
							<tr>
								<td colspan="2" class="tdbottom">Sistema Administrador de Puntos de Venta - 2003 
									Farmacias Benavides</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>

    </form>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
  </body>
</html>
