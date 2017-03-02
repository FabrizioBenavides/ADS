<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" enableViewState="False" Explicit="True" Trace="False" Strict="True" CodeBehind="VentasPromocionesMonederoAdministrar.aspx.vb"      Inherits="com.isocraft.backbone.ccentral.VentasPromocionesMonederoAdministrar" codePage="28592" %>
<HTML>
<HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/menu.css" type="text/css" rel="stylesheet">
<link href="css/estilo.css" type="text/css" rel="stylesheet">
<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/calendario.js"></script>
<script language="JavaScript" src="js/cal_format00.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script language="javascript" id="clientEventHandlersJS">

<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strFormAction %>";
  
  document.forms[0].optPromocionTipo["<%= intOpcPromocionTipo %>"].checked = true;
  document.forms[0].optPromocionVigencia["<%= intOpcPromocionVigencia %>"].checked = true;
  document.forms[0].optPromocionNombre.value = "<%=strPromocionNombre %>";
  document.forms[0].txtInicio.value = "<%=strInicio %>";
  document.forms[0].txtFin.value = "<%=strFin %>";
      
  <%= strJavascriptWindowOnLoadCommands %>;
  
}


function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];
    var params = "";
    var url = "";
    
    if (action=="AgregarPromocion") {       
       url = 'popVentasPromocionesMonederoAgregar.aspx';       
       var WinAgregar = window.open(url,'PopAgregar','width=720,height=600,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );

       return;
    }
    
    if(action=="ModificarEstado") {
	   url = 'popVentasPromocionesMonederoActualizar.aspx?';
	   	   
	   for (i=1; i < (args.length-1); i +=2) {
		params+= "&" + args[i] + "=" + args[i+1];		
	   }
	   
	   url = url + params;
       var WinEstado = window.open(url,'PopModificarE','width=720,height=600,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );
       
       return;
	}
	
	if(action=="ModificarDetalle") {
	   url = 'popVentasPromocionesMonederoDetalleCategoria.aspx?';
	          
	   for (i=1; i < (args.length-1); i +=2)  {
		  params+= "&" + args[i] + "=" + args[i+1];
		  		
		  if (args[i] == "strTipoPromocion" && args[i+1] == "ARTICULO") {
		     url = 'popVentasPromocionesMonederoDetalleArticulo.aspx?';
		  }		
	   }
	   
	   url = url + params;
       var WinDetalle = window.open(url,'PopModificarD','width=720,height=600,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );
       
       return;
	}
	
	if(action=="ModificarSucursalesFiltro") {
	   url = 'popVentasPromocionesMonederoRelacionSucursal.aspx?';
	          
	   for (i=1; i < (args.length-1); i +=2)  {
		  params+= "&" + args[i] + "=" + args[i+1];	
	   }
	   
	   url = url + params;
       var WinDetalle = window.open(url,'PopModificarS','width=720,height=600,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );
       
       return;
	}
	
    if(action=="ModificarSucursalesArchivo") {
	   url = 'popVentasPromocionesMonederoRelacionSucursalArchivo.aspx?';
	          
	   for (i=1; i < (args.length-1); i +=2)  {
		  params+= "&" + args[i] + "=" + args[i+1];	
	   }
	   
	   url = url + params;
       var WinDetalle = window.open(url,'PopModificarS','width=720,height=600,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );
       
       return;
	}
	
	var params = ""
	for (i=1; i < (args.length-1); i +=2) 	{
		params+= "&" + args[i] + "=" + args[i+1]
	}
	
	document.forms[0].action = "VentasPromocionesMonederoAdministrar.aspx?strCmd=" + action + params;
	document.forms[0].submit(); 	
}

function cmdRegresar_onclick() {
    window.location='VentasPromocionesMonedero.aspx';
}


function cmdEjecutar_onclick() {
   document.forms[0].action = '<%=strFormAction%>';
   document.forms[0].submit();
}

function cmdLimpiar_onclick() {
  window.location.href = '<%= strThisPageName %>';
}
//-->
</script>
</head>
<body language="javascript" onLoad="return window_onload()">
<form name="frmPromocionesMonederoAdministrar" action="about:blank" method="post">
  <table cellspacing="0" cellpadding="0" width="780" border="0">
    <tr> 
      <td><script language="JavaScript">crearTablaHeader()</script> </td>
    </tr>
  </table>
  <table cellspacing="0" cellpadding="0" width="780" border="0">
    <tr> 
      <td width="10">&nbsp;</td>
      <td class="tdtab" width="770">Está en : <a href="VentasHome.aspx">Ventas</a> 
        :<a href="VentasPromocionesMonedero.aspx">Promociones Monedero</a>:Administrar</td>
    </tr>
  </table>
  <table cellspacing="0" cellpadding="0" width="780" border="0">
    <tr> 
      <td class="tdgeneralcontent"><h1>Promociones de Monedero</h1>
        <p>En esta parte se consultan, modifican y agregan las promociones de 
          monedero electronico.</p>
        <h2>Criterio de Busqueda</h2>
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
          <tr> 
            <td width="40%" class="tdTituloAzul" valign="top" >Tipo Promoción</td>
            <td width="20%">&nbsp;&nbsp;</td>
            <td width="40%" class="tdTituloAzul" valign="top" >Vigencia Promoción</td>
          </tr>
          <tr> 
            <td width="40%" class="tdtexttablebold" valign="top"><input type="radio" value="0" name="optPromocionTipo">
              Todas</td>
            <td width="20%">&nbsp;&nbsp;</td>
            <td width="40%" class="tdtexttablebold" valign="top"><input type="radio" value="0" name="optPromocionVigencia">
              Todas</td>
          </tr>
          <tr> 
            <td width="40%" class="tdtexttablebold" valign="top"><input type="radio" value="1" name="optPromocionTipo">
              Por Categoria</td>
            <td width="20%">&nbsp;&nbsp;</td>
            <td width="40%" class="tdtexttablebold" valign="top"><input type="radio" value="1" name="optPromocionVigencia">
              Solo Vigentes</td>
          </tr>
          <tr> 
            <td width="40%" class="tdtexttablebold" valign="top"><input type="radio" value="2" name="optPromocionTipo">
              Por Articulo</td>
            <td width="20%">&nbsp;&nbsp;</td>
            <td width="40%" class="tdtexttablebold" valign="top"><input type="radio" value="2" name="optPromocionVigencia">
              No Vigentes</td>
          </tr>
          <tr> 
            <td width="40%" class="tdtexttablebold" valign="top">Descripción: 
              &nbsp; <input class="field" id="optPromocionNombre" type="text" autocomplete="off"  maxlength="50" size="40" name="optPromocionNombre"  value='<%=Request("optPromocionNombre")%>'> 
            </td>
            <td width="20%">&nbsp;&nbsp;</td>
            <td width="40%" class="tdtexttablebold" valign="top">Vigencia: &nbsp; 
              <input class="field" id="txtInicio" type="text" maxLength="12" size="12" name="txtInicio"> 
              <a href="javascript:cal1.popup()"><IMG height="15" src="images/imgCalendarIcon.gif" width="16" align="absMiddle" border="0"></a> 
              &nbsp;&nbsp;&nbsp;&nbsp; <input class="field" id="txtFin" type="text" maxLength="12" size="12" name="txtFin"> 
              <a href="javascript:cal2.popup()"><IMG height="15" src="images/imgCalendarIcon.gif" width="16" align="absMiddle" border="0"></a> 
            </td>
          </tr>
          <tr> 
            <td width="100%" colspan="3" height="10"><img height="10" src="images/pixel.gif" width="1"></td>
          </tr>
        </table>
        <input class="boton" id="cmdRegresar" type="button" value="Regresar" name="cmdRegresar"
							language="javascript" onclick="return cmdRegresar_onclick()"> 
        &nbsp; <input name='cmdAgregar' type='button' class='boton' value='Agregar Promoción' language='javascript' onclick='return doSubmit("AgregarPromocion")'> 
        &nbsp; <input class="boton" id="cmdEjecutar" type="button" value="Ejecutar consulta" name="cmdEjecutar"
							language="javascript" onclick="return cmdEjecutar_onclick()"> 
        &nbsp; <input class="boton" id="cmdLimpiar" type="button" value="Limpiar" name="cmdLimpiar" language="javascript"
							onclick="return cmdLimpiar_onclick()"> <br> <br> <%=strConsultarPromocionesMonedero%> 
        <br> </td>
    </tr>
  </table>
  <table cellspacing="0" cellpadding="0" width="780" border="0">
    <tr> 
      <td><script language="JavaScript">crearTablaFooterCentral()</script> </td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
			</script>
  <script language="JavaScript">
    <!-- // create calendar object(s) just after form tag closed
    var cal1 = new calendar(null, document.forms['frmPromocionesMonederoAdministrar'].elements['txtInicio']);
    var cal2 = new calendar(null, document.forms['frmPromocionesMonederoAdministrar'].elements['txtFin']);
    //-->
</script>
</form>
</body>
</HTML>
