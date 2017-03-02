<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FotoLabEmpleadosAsignarRoles.aspx.vb" Inherits="com.isocraft.backbone.ccentral.FotoLabEmpleadosAsignarRoles"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador de Puntos de Venta</title>
		<%  '====================================================================
    ' Page          : FotoLabEmpleadosAsignarRoles.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página mediante la cual se pueden Asignar Roles a los Empleados    
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Viernes, 03 Diciembre 2004
    '====================================================================
%>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link rel="stylesheet" href="../static/css/menu.css">
		<link rel="stylesheet" href="../static/css/menu2.css">
		<link rel="stylesheet" href="../static/css/estilo.css">
		<script language="javascript" id="clientEventHandlersJS">
<!--

var blnContrasenaModificada = false;

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
   document.forms[0].elements['txtUsuarioContrasena'].value = "<%=strUsuarioContrasenaEmpleado%>";
   document.forms[0].elements['txtConfirmaUsuarioContrasena'].value = "<%=strUsuarioContrasenaEmpleado%>";
   
   document.forms[0].elements['optHabilitado'][0].checked = false;
   document.forms[0].elements['optHabilitado'][1].checked = false;
   
   document.forms[0].elements['optCuentaBloqueada'][0].checked = false;
   document.forms[0].elements['optCuentaBloqueada'][1].checked = false;

    if (<%= blnUsuarioHabilitado %> == 1) {
        document.forms[0].elements['optHabilitado'][0].checked = true;
    } else {
    	document.forms[0].elements['optHabilitado'][1].checked = true;
    }    
    if (<%= blnUsuarioBloqueado %> == 1) {
        document.forms[0].elements['optCuentaBloqueada'][0].checked = true;
    } else {
    	document.forms[0].elements['optCuentaBloqueada'][1].checked = true;
    }
    if (<%= strChangePassword %> == true) {
        alert("Su cuenta de acceso dejará de funcionar en 3 días. Por favor actualice su contraseña.");
    }
    
    <%= strWindowOnLoadEvent %>
       
    if ("<%=strCmd %>" == "Salvar") {
       window.location="FotoLabEmpleadosAdministrar.aspx";      
    }
   
    return(true);
}

function strCompaniaSucursal() {
	document.write(<%=intCompaniaId%> + " - " + <%=intSucursalId%>);
	return(true);
}

function strSucursalNombre() {
	document.write("&nbsp;"+"<%=strSucursalNombre%>");
	return(true);
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}

function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
	return(true);
}

function strUsuarioNombreEmpleado(){
	document.write("<%=strUsuarioNombreEmpleado%>");
	return(true);
}

function cmdRegresar_onclick() {
	window.location="FotoLabEmpleadosAdministrar.aspx";
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

function intPuestoEmpleadoId(){
	document.write(<%=intPuestoEmpleadoId%>);
	return(true);
}

function dtmUsuarioExpiracion(){
	document.write("<%=dtmUsuarioExpiracion%>");
	return(true);
}

function dtmAsignacionRol(){
 document.write("<%=dtmUsuarioAsignacion%>");
 return(true);
}

String.prototype.trim = function()
{
    return this.replace(/(^\s*)|(\s*$)/g, "");
}

function frmFotoLabEmpleadosAsignarRoles_onsubmit(objForm) {

  // Validaciones para el campo txtUsuarioContrasena
  if (objForm.txtUsuarioContrasena.value == "")
  {
    alert("Por favor escriba un valor en el campo \"Contrasena\".");
    objForm.txtUsuarioContrasena.focus();
    return(false);
  }

  if (objForm.txtUsuarioContrasena.value.length > 15)
  {
    alert("Por favor escriba a lo más 15 caracteres en el campo \"Contrasena\".");
    objForm.txtUsuarioContrasena.focus();
    return(false);
  }

  var checkOK = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzfSOZsozYRÁÂAÄLCÇCÉEËEÍÎDDNNÓÔOÖRUÚUÜÝTßráâaälcçcéeëeíîddnnóôoöruúuüýt?0123456789-";
  var checkStr = objForm.txtUsuarioContrasena.value;
  var allValid = true;
  for (i = 0;  i < checkStr.length;  i++)
  {
    ch = checkStr.charAt(i);
    for (j = 0;  j < checkOK.length;  j++)
      if (ch == checkOK.charAt(j))
        break;
    if (j == checkOK.length)
    {
      allValid = false;
      break;
    }
  }
  
  if (blnContrasenaModificada == true) {
  if (!allValid)
  {
    alert("Por favor escriba únicamente caracteres y dígitos en el campo \"Contrasena\".");
    objForm.txtUsuarioContrasena.focus();
    return(false);
  }
  }

   // Realizamos la validacion de la confirmacion de la Contrasena
	if (objForm.txtConfirmaUsuarioContrasena.value =="")
  {
	alert("Por favor escriba un valor para confirmar la Contrasena");
	objForm.txtConfirmaUsuarioContrasena.focus();
	return(false);
  }
  
  if (objForm.txtConfirmaUsuarioContrasena.value.length > 15)
  {
    alert("Por favor escriba a lo más 15 caracteres en el campo de Confirmación \"Contrasena\".");
    objForm.txtUsuarioContrasena.focus();
    return (false);
  }
  
  checkStr = objForm.txtConfirmaUsuarioContrasena.value;
  allValid = true;
  for (i = 0;  i < checkStr.length;  i++)
  {
    ch = checkStr.charAt(i);
    for (j = 0;  j < checkOK.length;  j++)
      if (ch == checkOK.charAt(j))
        break;
    if (j == checkOK.length)
    {
      allValid = false;
      break;
    }
  }
  if (blnContrasenaModificada == true) {
  if (!allValid)
  {
    alert("Por favor escriba únicamente caracteres y dígitos en el campo de Confirmación \"Contrasena\".");
    objForm.txtConfirmaUsuarioContrasena.focus();
    return (false);
  }
  }
 // Verificamos que la contrasena original no sea igual a la nueva asignada 
  if (blnContrasenaModificada == true){
  if (objForm.txtUsuarioContrasena.value == objForm.txtUsuarioContrasenaOriginal.value){
	 alert("Por favor escriba una contrasena diferente a la original.");
	 objForm.txtUsuarioContrasena.focus();
	 return(false);
    }   
  }
  
  if ("<%=strUsuarioNombreEmpleado%>" == objForm.txtUsuarioContrasena.value){
   alert("La contrasena debe ser diferente al nombre de usuario.");
   return(false);
  }
  
  // Validamos que la Contrasena sea identica a su Confirmacion  
  if (objForm.txtUsuarioContrasena.value != objForm.txtConfirmaUsuarioContrasena.value){
   alert("La contrasena y su confirmación no tienen el mismo valor."); 
   objForm.txtUsuarioContrasena.focus();
   return(false);
  } 
  
  // Agregamos la operacion a realizar
  document.forms[0].action += "&strCmd=Salvar&blnContrasenaModificada=" + blnContrasenaModificada + "&intUsuarioId=" + <%=intUsuarioId%>;
  return(true);
  
}

function txtUsuarioContrasena_onchange() {
  blnContrasenaModificada = true;
  return(true);
}

//-->
		</script>
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
		<form action="about:blank" method="post" name="frmFotoLabEmpleadosAsignarRoles" onSubmit="return frmFotoLabEmpleadosAsignarRoles_onsubmit(this)">
			<table width="780" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td><table width="780" border="0" cellpadding="0" cellspacing="0">
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
								<td width="583" class="tdmigaja"><span class="txdmigaja">Está en :</span><span class="txdmigaja">
										<a href="FotoLab.aspx" class="txdmigaja">Sucursal</a> : <a href="FotoLab.aspx" class="txdmigaja">
											Empleados</a> : <a href="FotoLabEmpleadosAdministrar.aspx" class="txdmigaja">Administrar 
											roles del personal</a> : Asignar roles a empleados</span></td>
								<td width="187" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script>
								</td>
							</tr>
							<tr>
								<td width="10">&nbsp;</td>
								<td width="583" valign="top"><table width="583" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td width="100%" colspan="3" valign="top" class="tdtablacont"><span class="txtitulo">Asignar 
													roles a empleados<br>
												</span><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Usuario 
													y rol</span> <span class="txtitulo"></span>
												<table width="100%" border="0" cellpadding="0" cellspacing="0">
													<tr>
														<td width="133" class="tdtittablas">No. de empleado:</td>
														<td colspan="2" valign="middle" class="tdconttablas"><script language="JavaScript">intEmpleadoId()</script>
															&nbsp;&nbsp; <span class="txconttablasrojo">
																<script language="JavaScript">strEmpleadoNombre()</script>
																&nbsp;
																<script language="JavaScript">strEmpleadoApellidoPaterno() </script>
																&nbsp;
																<script language="JavaScript">strEmpleadoApellidoMaterno() </script>
															</span>
														</td>
													</tr>
													<tr>
														<td class="tdtittablas">Puesto:</td>
														<td width="131" valign="middle" class="tdconttablas"><script language="JavaScript">intPuestoEmpleadoId()</script>
														</td>
														<td width="304" valign="middle" class="tdtittablas">&nbsp;</td>
													</tr>
													<tr>
														<td class="tdtittablas">Usuario:</td>
														<td valign="middle" class="tdconttablas">&nbsp;
															<script language="JavaScript">strUsuarioNombreEmpleado()</script>
														</td>
														<td valign="middle" class="tdtittablas">&nbsp;</td>
													</tr>
													<tr>
														<td class="tdtittablas">Contraseña:</td>
														<td valign="middle" class="tdpadleft5">
															<input name="txtUsuarioContrasena" type="password" class="campotabla" size="21" maxlength="21"
																language="javascript" onChange="return txtUsuarioContrasena_onchange()">
														</td>
														<td valign="middle" class="tdconttablas">Si quiere cambiar la contraseña, escriba 
															sobre la actual.</td>
													</tr>
													<tr>
														<td class="tdtittablas">Confirma Contraseña:&nbsp;</td>
														<td valign="middle" class="tdpadleft5">
															<input name="txtConfirmaUsuarioContrasena" type="password" class="campotabla" id="txtConfirmaUsuarioContrasena"
																size="21" maxlength="21" language="javascript">
														</td>
														<td valign="middle" class="tdconttablas">&nbsp;
														</td>
													</tr>
													<tr>
														<td class="tdtittablas">Rol:</td>
														<td valign="middle" class="tdconttablas"><span class="txsubtitulo">FOTOLAB</span></td>
														<td valign="middle" class="tdconttablas"><input type="hidden" name="txtUsuarioContrasenaOriginal">
														</td>
													</tr>
													<tr>
                        <td class="tdtittablas">Estatus:</td>
                        <td colspan="2" valign="middle" class="tdconttablas"><input name="optHabilitado" type="radio" value="1" />
                          Habilitado&nbsp;
                          <input name="optHabilitado" type="radio" value="0" />
                          Deshabilitado</td>
                      </tr>
													<tr>
														<td class="tdtittablas">¿Cuenta bloqueada?
														</td>
														<td valign="middle" class="tdconttablas"><input name="optCuentaBloqueada" type="radio" value="1">
															Sí&nbsp; <input name="optCuentaBloqueada" type="radio" value="0"> No</td>
														<td valign="middle" class="tdconttablas">(Rebasado el número máximo de contraseñas 
															erróneas)
														</td>
													</tr>
												</table>
												<br>
												<input name="cmdRegresar" type="button" class="boton" id="cmdRegresar" value="Regresar"
													onClick="return cmdRegresar_onclick()"> &nbsp;&nbsp; <input name="cmdEjecutarAsignacion" type="submit" class="boton" id="cmdEjecutarAsignacion"
													value="Ejecutar asignación"> &nbsp;&nbsp;
												<br>
												<br>
												<br>
												<span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Asignación 
													y vigencia</span> <span class="txtitulo"></span>
												<table width="100%" border="0" cellpadding="0" cellspacing="0">
													<tr>
														<td width="183" class="tdtittablas">Fecha de asignación del rol:</td>
														<td valign="middle" class="tdconttablas"><script language="javascript">dtmAsignacionRol()</script>
														</td>
													</tr>
													<tr>
														<td class="tdtittablas">Contraseña vigente hasta:</td>
														<td width="385" valign="middle" class="tdconttablasrojo"><script language="JavaScript">dtmUsuarioExpiracion()</script>
														</td>
													</tr>
												</table>
												<br>
											</td>
										</tr>
									</table>
								</td>
								<td width="187" rowspan="2" valign="top" class="tdcolumnader">&nbsp;
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
	</body>
</HTML>
