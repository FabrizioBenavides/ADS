// ====================================================================
//  Filename      : tools.js
//  Title         : Grupo Benavides. Administrador POS y Backoffice.
//  Description   : Funciones globales.
//  Copyright     : (c) Isocraft 2004 - 2009. All rights reserved
//  Company       : Isocraft. (http://www.isocraft.com/)
//  Author        : Joaquín Hdz. G. (joaquin@isocraft.com)
//  Last Modified : Wednesday, December 15, 2004
// ====================================================================

// ====================================================================
//  INICIA derechos reservados
// ====================================================================

n = (document.layers) ? 1:0
ie = (document.all) ? 1:0

function klick(e) {
  if (ie && event.button==2) {
    alert("Benavides S.A. de C.V., " + (new Date()).getFullYear() + " Derechos Reservados.");
  }
  if (n) {
    if (e.which==3)
      return false;
  }
}

document.onmousedown = klick;

if (n) document.captureEvents(Event.MOUSEDOWN)


// ====================================================================
//  TERMINA validar F5 y Ctrl R y BackSpace
// ====================================================================

if (document.all) {             
  document.onkeydown = function () {
    var key_f5 = 116; // 116 = F5         
    if (key_f11==event.keyCode) {
      alert("F5 pressed");
      return false;
    }
  }
}

function showDown(evt) {
  evt = (evt) ? evt : ((event) ? event : null);
  if (evt) {
    if (event.keyCode == 8 && (event.srcElement.type != "text" && event.srcElement.type != "textarea" && event.srcElement.type != "password")) {
      // When backspace is pressed but not in form element
      cancelKey(evt);
    }
    else if (event.keyCode == 116) {
      // When F5 is pressed
      cancelKey(evt);
    }
    else if (event.ctrlKey && (event.keyCode == 78 || event.keyCode == 82)) {
      // When ctrl is pressed with R or N
      cancelKey(evt);
    }
  }
}

function cancelKey(evt) {
  if (evt.preventDefault) {
    evt.preventDefault();
    return false;
  }
  else {
    evt.keyCode = 0;
    evt.returnValue = false;
  }
}

// Additional code for NS
if (navigator.appName=="Netscape") {
  document.addEventListener("keypress", showDown, true);
}

document.onkeydown  = showDown;


// ====================================================================
//  INICIA funciones generales
// ====================================================================

// False muestra mensajes en 'alerts' ó True en ShowModal Page
var cblnMostrarShowModalDialog = false;

// Atributos de la ventana de alert
var cstrAtributosVentana = "dialogWidth:305px;dialogHeight:145px;dialogTop:225px;dialogLeft:250px;status:no;help:no;"

// Constantes con los valores permitidos en los campos
var cstrCadenaAlfanumerico          = " <>;:()¿?_,!¡#@$%+-*/.0123456789áéíóúÁÉÍÓÚqwertyuiopasdfghjklñzxcvbnmQWERTYUIOPASDFGHJKLÑZXCVBNM";
var cstrCadenaAlfanumericoConPipe   = " |<>;:()¿?_,!¡#@$%+-*/.0123456789áéíóúÁÉÍÓÚqwertyuiopasdfghjklñzxcvbnmQWERTYUIOPASDFGHJKLÑZXCVBNM";
var cstrCadenaAlfanumericoExtendido = " <>;:()¿?_,!¡#@$%+-*/.0123456789áéíóúÁÉÍÓÚqwertyuiopasdfghjklñzxcvbnmQWERTYUIOPASDFGHJKLÑZXCVBNM\n\r";
var cstrCadenaNumerosReales         = "0123456789,.-";
var cstrCadenaNumerosEnteros        = "0123456789";

// Constantes con los tipos de campos
var cintTipoCampoCadenaDefinida        = 0;
var cintTipoCampoFecha                 = 100;
var cintTipoCampoReal                  = 200;
var cintTipoCampoEntero                = 300;
var cintTipoCampoAlfanumerico          = 400;
var cintTipoCampoAlfanumericoConPipe   = 450;
var cintTipoCampoCombo                 = 500;
var cintTipoCampoAlfanumericoExtendido = 500;

// Atributos del menu
var blnMenuAbierto = false;


function cmdBuscarImg_onclick() {
  document.forms[0].action = "/default.aspx";
  document.forms[0].submit();
  return(true);
}

function cmdSalirImg_onclick() {
  window.location = "/Default.aspx?strCmd=Salir";
  return(true);
}

function strEliminaGuiones(objCampo) {
  var strInicial, strFinal, strResultado;
  strInicial = objCampo;
  strFinal = strInicial.split("-");
  strResultado = '';
  for (intContador = 0; intContador < strFinal.length; intContador++) {
    strResultado = strResultado + strFinal[intContador];  
  }
  return(strResultado); 
}

function printContent() {
  if (window.print) {
    document.ifrPageToPrint.document.all.ToPrintTxtMigaja.innerHTML=document.all.ToPrintTxtMigaja.innerText;
    document.ifrPageToPrint.document.all.ToPrintTxtFecha.innerHTML=document.all.ToPrintTxtFecha.innerText;
    document.ifrPageToPrint.document.all.ToPrintTxtSucursal.innerHTML=document.all.ToPrintTxtSucursal.innerText;
    document.ifrPageToPrint.document.all.ToPrintHtmContenido.innerHTML=document.all.ToPrintHtmContenido.innerHTML;
    document.ifrPageToPrint.focus();
    window.print();        
  } else {
    alert("Tu navegador no soporta la función: Print.")
  }
}

function printContent2() {
    if (window.print) {
        document.ifrPageToPrint.document.all.ToPrintTxtMigaja.innerHTML = document.all.ToPrintTxtMigaja.innerText;
        document.ifrPageToPrint.document.all.ToPrintHtmContenido.innerHTML = document.all.ToPrintHtmContenido.innerHTML;
        document.ifrPageToPrint.focus();
        window.print();
    } else {
        alert("Tu navegador no soporta la función: Print.")
    }
}

function MostrarMensaje(objCampo, strEtiquetaCampo, intTipoCampo, intNoMensaje, intLength, strCaracterNoValido) 
{
  strMsgShowModal="";
  strMsgAlert="";
  //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
  if(intTipoCampo==cintTipoCampoCadenaDefinida) {
    if(intNoMensaje==0) { //Es Requerido y no seleccionó nada del control
      strMsgShowModal  ="No puede quedar vacío";
      strMsgAlert    ="Por favor establezca un valor para el campo \"" + strEtiquetaCampo + "\".";
    }
    
    if(intNoMensaje==5) { //Longitud excedida
      strMsgShowModal  ="La longitud debe ser menor[<] o igual[=] a "+ intLength.toString();
      strMsgAlert    ="En campo \"" + strEtiquetaCampo + "\", " + "la longitud debe ser menor[<] o igual[=] a "+ intLength.toString();
    }
    if(intNoMensaje==6) { //Longitud requerida
      strMsgShowModal  ="La longitud debe ser mayor[>] o igual[=] a "+ intLength.toString();
      strMsgAlert    ="En campo \"" + strEtiquetaCampo + "\", " + "la longitud debe ser mayor[>] o igual[=] a "+ intLength.toString();
    }
    if(intNoMensaje==7) { //Caracteres no validos
      strMsgShowModal  ="Contiene caracteres no válidos: " + strCaracterNoValido;
      strMsgAlert    ="El campo \"" + strEtiquetaCampo + "\", contiene caracteres no válidos: " + strCaracterNoValido;
    }
  }
  //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
  if(intTipoCampo==cintTipoCampoFecha) {
    if(intNoMensaje==0) { //Es Requerido y no seleccionó nada del control
      strMsgShowModal  ="Por favor introduzca una fecha en el campo. Formato válido: (dd/mm/aaaa)";
      strMsgAlert    ="Por favor introduzca una fecha en el campo \""+ strEtiquetaCampo +"\", Formato válido: (dd/mm/aaaa)";
    }
    if(intNoMensaje==1) { //
      strMsgShowModal  ="Mes capturado no es valido. Formato válido: (dd/mm/aaaa)";
      strMsgAlert    ="Mes capturado no es valido." + " En el campo \"" + strEtiquetaCampo + "\", Formato válido: (dd/mm/aaaa)"
    }
    if(intNoMensaje==2) { //
      strMsgShowModal  ="Día capturado no es valido. Formato válido: (dd/mm/aaaa)";
      strMsgAlert    ="Día capturado no es valido." + " En el campo \"" + strEtiquetaCampo + "\", Formato válido: (dd/mm/aaaa)"
    }
    if(intNoMensaje==3) { //
      strMsgShowModal  ="Año capturado no es valido. Formato válido: (dd/mm/aaaa)";
      strMsgAlert    ="A\361o capturado no es valido." + " En el campo \"" + strEtiquetaCampo + "\", Formato válido: (dd/mm/aaaa)"
    }
    if(intNoMensaje==4) { //
      strMsgShowModal  ="Fecha capturada no es valida. Formato válido: (dd/mm/aaaa)";
      strMsgAlert    ="Fecha capturada no es valida." + " En el campo \"" + strEtiquetaCampo + "\", Formato válido: (dd/mm/aaaa)"
    }
    if(intNoMensaje==5) { //Longitud excedida
      strMsgShowModal  ="La longitud debe ser menor[<] o igual[=] a "+ intLength.toString();
      strMsgAlert    ="En el campo \"" + strEtiquetaCampo + "\", " + "la longitud debe ser menor[<] o igual[=] a "+ intLength.toString();
    }
    if(intNoMensaje==6) { //Longitud requerida
      strMsgShowModal  ="La longitud debe ser mayor[>] o igual[=] a "+ intLength.toString();
      strMsgAlert    ="En el campo \"" + strEtiquetaCampo + "\", " + "la longitud debe ser mayor[>] o igual[=] a "+ intLength.toString();
    }
    
  }
  //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
  if(intTipoCampo==cintTipoCampoReal) {
    if(intNoMensaje==0) { //Es Requerido y no seleccionó nada del control
      strMsgShowModal  ="No puede quedar vacío";
      strMsgAlert    ="Por favor establezca un valor para el campo \"" + strEtiquetaCampo + "\".";
    }
    
    if(intNoMensaje==5) { //Longitud excedida
      strMsgShowModal  ="La longitud debe ser menor[<] o igual[=] a "+ intLength.toString();
      strMsgAlert    ="En el campo \"" + strEtiquetaCampo + "\", " + "la longitud debe ser menor[<] o igual[=] a "+ intLength.toString();
    }
    if(intNoMensaje==6) { //Longitud requerida
      strMsgShowModal  ="La longitud debe ser mayor[>] o igual[=] a "+ intLength.toString();
      strMsgAlert    ="En el campo \"" + strEtiquetaCampo + "\", " + "la longitud debe ser mayor[>] o igual[=] a "+ intLength.toString();
    }
    
    if(intNoMensaje==8) { //Debe ser numerico real
      strMsgShowModal  ="El valor proporcionado debe ser númerico.";
      strMsgAlert    ="En el campo \"" + strEtiquetaCampo + "\", " + "el valor proporcionado debe ser númerico.";
    }
    
  }
  //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
  if(intTipoCampo==cintTipoCampoEntero) {
    if(intNoMensaje==0) { //Es Requerido y no seleccionó nada del control
      strMsgShowModal  ="No puede quedar vacío";
      strMsgAlert    ="Por favor establezca un valor para el campo \"" +strEtiquetaCampo + "\".";
    }
    
    if(intNoMensaje==5) { //Longitud excedida
      strMsgShowModal  ="La longitud debe ser menor[<] o igual[=] a "+ intLength.toString();
      strMsgAlert    ="En el campo \"" + strEtiquetaCampo + "\", " + "la longitud debe ser menor[<] o igual[=] a "+ intLength.toString();
    }
    if(intNoMensaje==6) { //Longitud requerida
      strMsgShowModal  ="La longitud debe ser mayor[>] o igual[=] a "+ intLength.toString();
      strMsgAlert    ="En el campo \"" + strEtiquetaCampo + "\", " + "la longitud debe ser mayor[>] o igual[=] a "+ intLength.toString();
    }
    
    if(intNoMensaje==8) { //Debe ser numerico real
      strMsgShowModal  ="El valor proporcionado debe ser un número entero.";
      strMsgAlert    ="En el campo \"" + strEtiquetaCampo + "\", " + "el valor proporcionado debe ser un número entero.";
    }
  }
  //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
  if(intTipoCampo==cintTipoCampoAlfanumerico) {
      strMsgShowModal  ="No puede quedar vacío";
    strMsgAlert    ="Por favor establezca un valor para el campo \"" + strEtiquetaCampo + "\".";
    if(intNoMensaje==0) { //Es Requerido y no seleccionó nada del control
      strMsgShowModal  ="No puede quedar vacío";
      strMsgAlert    ="Por favor establezca un valor para el campo \"" + strEtiquetaCampo + "\".";
    }
    
    if(intNoMensaje==5) { //Longitud excedida
      strMsgShowModal  ="La longitud debe ser menor[<] o igual[=] a "+ intLength.toString();
      strMsgAlert    ="En el campo \"" + strEtiquetaCampo + "\", " + "la longitud debe ser menor[<] o igual[=] a "+ intLength.toString();
    }
    if(intNoMensaje==6) { //Longitud requerida
      strMsgShowModal  ="La longitud debe ser mayor[>] o igual[=] a "+ intLength.toString();
      strMsgAlert    ="En el campo \"" + strEtiquetaCampo + "\", " + "la longitud debe ser mayor[>] o igual[=] a "+ intLength.toString();
    }
    if(intNoMensaje==7) { //Caracteres no validos
      strMsgShowModal  ="Contiene caracteres no válidos: " + strCaracterNoValido;
      strMsgAlert    ="El campo \"" + strEtiquetaCampo + "\", contiene caracteres no válidos: " + strCaracterNoValido;
    }
  }
    //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
  if(intTipoCampo==cintTipoCampoAlfanumericoConPipe) {
      strMsgShowModal  ="No puede quedar vacío";
    strMsgAlert    ="Por favor establezca un valor para el campo \"" + strEtiquetaCampo + "\".";
    if(intNoMensaje==0) { //Es Requerido y no seleccionó nada del control
      strMsgShowModal  ="No puede quedar vacío";
      strMsgAlert    ="Por favor establezca un valor para el campo \"" + strEtiquetaCampo + "\".";
    }
    
    if(intNoMensaje==5) { //Longitud excedida
      strMsgShowModal  ="La longitud debe ser menor[<] o igual[=] a "+ intLength.toString();
      strMsgAlert    ="En el campo \"" + strEtiquetaCampo + "\", " + "la longitud debe ser menor[<] o igual[=] a "+ intLength.toString();
    }
    if(intNoMensaje==6) { //Longitud requerida
      strMsgShowModal  ="La longitud debe ser mayor[>] o igual[=] a "+ intLength.toString();
      strMsgAlert    ="En el campo \"" + strEtiquetaCampo + "\", " + "la longitud debe ser mayor[>] o igual[=] a "+ intLength.toString();
    }
    if(intNoMensaje==7) { //Caracteres no validos
      strMsgShowModal  ="Contiene caracteres no válidos: " + strCaracterNoValido;
      strMsgAlert    ="El campo \"" + strEtiquetaCampo + "\", contiene caracteres no válidos: " + strCaracterNoValido;
    }
  }
  //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
  if(intTipoCampo==cintTipoCampoAlfanumericoExtendido) {
      strMsgShowModal  ="No puede quedar vacío";
    strMsgAlert    ="Por favor establezca un valor para el campo \"" + strEtiquetaCampo + "\".";
    if(intNoMensaje==0) { //Es Requerido y no seleccionó nada del control
      strMsgShowModal  ="No puede quedar vacío";
      strMsgAlert    ="Por favor establezca un valor para el campo \"" + strEtiquetaCampo + "\".";
    }
    
    if(intNoMensaje==5) { //Longitud excedida
      strMsgShowModal  ="La longitud debe ser menor[<] o igual[=] a "+ intLength.toString();
      strMsgAlert    ="En el campo \"" + strEtiquetaCampo + "\", " + "la longitud debe ser menor[<] o igual[=] a "+ intLength.toString();
    }
    if(intNoMensaje==6) { //Longitud requerida
      strMsgShowModal  ="La longitud debe ser mayor[>] o igual[=] a "+ intLength.toString();
      strMsgAlert    ="En el campo \"" + strEtiquetaCampo + "\", " + "la longitud debe ser mayor[>] o igual[=] a "+ intLength.toString();
    }
    if(intNoMensaje==7) { //Caracteres no validos
      strMsgShowModal  ="Contiene caracteres no válidos: " + strCaracterNoValido;
      strMsgAlert    ="El campo \"" + strEtiquetaCampo + "\", contiene caracteres no válidos: " + strCaracterNoValido;
    }
  }
  //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
  if(intTipoCampo==cintTipoCampoCombo) {
    if(intNoMensaje==1) { //Es Requerido y no seleccionó nada del la Lista  Combo
      strMsgShowModal  ="Seleccione un " + strEtiquetaCampo +".";
      strMsgAlert    ="Seleccione un \"" + strEtiquetaCampo +"\"";
    }
    if(intNoMensaje==2) { //Elemento seleccionado de la Lista  Combo no es permitido
      strMsgShowModal  ="Seleccione un " + strEtiquetaCampo +".";
      strMsgAlert    ="Seleccione un \"" + strEtiquetaCampo +"\"";
    }
  }
  //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
  if(cblnMostrarShowModalDialog) {
    window.showModalDialog("vShowModal.asp?msg="+strMsgShowModal+"&campo="+strEtiquetaCampo,"",cstrAtributosVentana);
  }
  else {
    alert(strMsgAlert);
  }
  
  if(objCampo.disabled == false) {
    objCampo.focus();
  }
}

function strTextoSeleccionadoEnCbo(objCbo) {
  intSelectedIndex = objCbo.selectedIndex;
  if(intSelectedIndex > -1) {
    strTextoCbo = objCbo(intSelectedIndex).text;
    return(strTextoCbo);
  } else {
    return('');
  }
}

function blnValidarCombo(objCampo,strDiferenteDe,strEtiquetaCampo,blnRequerido) {
  if(objCampo.selectedIndex<0 && blnRequerido) {
    objCampo.selectedIndex=0;
    MostrarMensaje(objCampo,strEtiquetaCampo,cintTipoCampoCombo,1)
    return(false);
  }
  //Solo validara cuando especifiquen que sea diferente de Algo
  if(strDiferenteDe!='') {
    if(objCampo.value==strDiferenteDe) {
      objCampo.selectedIndex=0;
      MostrarMensaje(objCampo,strEtiquetaCampo,cintTipoCampoCombo,2)
      return(false);
    }
  }
  return(true);
}

function fltObtenerNumero(strValor) {
  strCaracteresAOmitir = "$,";
  strFinal ="";
  for (i = 0;  i < strValor.length;  i++) {
    ch = strValor.charAt(i);
    blnChrInvalido = false;
    for (j = 0;  j < strCaracteresAOmitir.length;  j++) {
      if(ch == strCaracteresAOmitir.charAt(j)) {
        blnChrInvalido = true;
      }
    }
    if(blnChrInvalido==false) {
      strFinal = strFinal + ch;
    }
  }
  if(strFinal.length > 0) {
    strFinal = strFinal * 1;
    if(isNaN(strFinal)) {
      return(0);
    } else {
      return(strFinal);  
    }
  } else {
    return(0);
  }
}

function blnValidarCampo(objCampo, blnRequerido, strEtiquetaCampo, intTipoCampo, intMaxLength, intMinLength, strCadenaDefinida) {

  //Si no se requiero y no escribio Nada no es necesario Validar
  if ((blnRequerido==false) && (objCampo.value=="")) {
    return(true);
  }
  
  valor=objCampo.value;
  while(''+valor.charAt(0)==' ') {
    valor=valor.substring(1,valor.length);
  }
  
  if (blnRequerido && (valor=="")) {
    MostrarMensaje(objCampo,strEtiquetaCampo,intTipoCampo,0)
    return(false);
  }
  

  
  //TODAS Las validaciones solo se realizan, cuando hay datos en el Control a validar
  if (objCampo.value.length == 0) {
    MostrarMensaje(objCampo,strEtiquetaCampo,intTipoCampo,0)
  }
  
  if (intTipoCampo==cintTipoCampoFecha) {
      return(Valid_Date(objCampo.value,strEtiquetaCampo,objCampo))
  }
  
  if (intTipoCampo==cintTipoCampoReal ||intTipoCampo==cintTipoCampoEntero || intTipoCampo==cintTipoCampoAlfanumerico || intTipoCampo==cintTipoCampoAlfanumericoExtendido || intTipoCampo==cintTipoCampoCadenaDefinida) {
    if (valor.length >intMaxLength) {
      MostrarMensaje(objCampo,strEtiquetaCampo,intTipoCampo,5,intMaxLength) 
      return(false);
    }
    if (valor.length < intMinLength) {
      MostrarMensaje(objCampo,strEtiquetaCampo,intTipoCampo,6,intMinLength) 
      return(false);
    }
  }
  
  if (intTipoCampo==cintTipoCampoAlfanumerico) {  
    for (i = 0;  i < valor.length;  i++) {
      ch = valor.charAt(i);
      for (j = 0;  j < cstrCadenaAlfanumerico.length;  j++)
        if (ch == cstrCadenaAlfanumerico.charAt(j))
          break;
      if (j == cstrCadenaAlfanumerico.length) {
        MostrarMensaje(objCampo,strEtiquetaCampo,cintTipoCampoAlfanumerico,7,0,ch)
        return(false);
      }
    }
  }
  
    if (intTipoCampo==cintTipoCampoAlfanumericoConPipe) {  
    for (i = 0;  i < valor.length;  i++) {
      ch = valor.charAt(i);
      for (j = 0;  j < cstrCadenaAlfanumericoConPipe.length;  j++)
        if (ch == cstrCadenaAlfanumericoConPipe.charAt(j))
          break;
      if (j == cstrCadenaAlfanumericoConPipe.length) {
        MostrarMensaje(objCampo,strEtiquetaCampo,cintTipoCampoAlfanumericoConPipe,7,0,ch)
        return(false);
      }
    }
  }
  
  if (intTipoCampo==cintTipoCampoAlfanumericoExtendido) {  
    for (i = 0;  i < valor.length;  i++) {
      ch = valor.charAt(i);
      for (j = 0;  j < cstrCadenaAlfanumericoExtendido.length;  j++)
        if (ch == cstrCadenaAlfanumericoExtendido.charAt(j))
          break;
      if (j == cstrCadenaAlfanumericoExtendido.length) {
        MostrarMensaje(objCampo,strEtiquetaCampo,cintTipoCampoAlfanumericoExtendido,7,0,ch)
        return(false);
      }
    }
  }
  
 
  if (intTipoCampo==cintTipoCampoCadenaDefinida) {
    for (i = 0;  i < valor.length;  i++) {
      ch = valor.charAt(i);
      for (j = 0;  j < strCadenaDefinida.length;  j++)
        if (ch == strCadenaDefinida.charAt(j))
          break;
      if (j == strCadenaDefinida.length) {
        MostrarMensaje(objCampo,strEtiquetaCampo,cintTipoCampoCadenaDefinida,7,0,ch)
        return(false);
      }
    }
  }
  
  if (intTipoCampo==cintTipoCampoReal || intTipoCampo==cintTipoCampoEntero) {
    if (!(isNumericGral(valor,intTipoCampo))) {
      MostrarMensaje(objCampo,strEtiquetaCampo,intTipoCampo,8,0)
      return(false);
    }
  }

  if (intTipoCampo==cintTipoCampoReal ) {
    if (!(isCorrectReal(valor,intTipoCampo))) {
      MostrarMensaje(objCampo,strEtiquetaCampo,intTipoCampo,8,0)
      return(false);
    }
  }
  return(true); 
}


function isCorrectReal(Dato,intTipoCampo) {

  var EsteCaracter;
  var Contador = 0;
  
  for (var i=0; i < Dato.length; i++)  {
    EsteCaracter = Dato.substring(i, i+1);
      if (EsteCaracter=='.') {
        Contador ++;
      }
    }
    
   if (Contador==0) {
	  return(true);
	  }
	else if (Contador==1) {
	  return(true);
	  }
    else if (Contador>1) {
    return(false);
    }	   
    
    
}

function isNumericGral(Dato,intTipoCampo) {

  var CadenaNumeros="";

  if(intTipoCampo==cintTipoCampoReal) {
    CadenaNumeros = cstrCadenaNumerosReales; 
  }
  if(intTipoCampo==cintTipoCampoEntero) {
    CadenaNumeros = cstrCadenaNumerosEnteros;
  }
  
  var EsteCaracter;
  var Contador = 0;
  
  for (var i=0; i < Dato.length; i++)  {
    EsteCaracter = Dato.substring(i, i+1);
    if (CadenaNumeros.indexOf(EsteCaracter) != -1) {
      Contador ++;
    } else {
       // Solo al inicio para permitir numeros negativos
      if (EsteCaracter=='-' && i==0) {
        Contador ++;
      }
    }
  }
  
  if (Contador == Dato.length)
    return(true);
  else
    return(false);

}

function Valid_Date(datein, strEtiquetaCampo, objCampo) { 

  valor=objCampo.value;

  if (valor.length !==10) {
    MostrarMensaje(objCampo,strEtiquetaCampo,cintTipoCampoFecha,4)
    return false; 
  }
  
  if (valor.charAt(2)!== "/") {
    MostrarMensaje(objCampo,strEtiquetaCampo,cintTipoCampoFecha,4)
    return false; 
  }
  
  if (valor.charAt(5)!== "/") {
    MostrarMensaje(objCampo,strEtiquetaCampo,cintTipoCampoFecha,4)
    return false; 
  }
  
  if (valor.substr(0,2)> 31) {
    MostrarMensaje(objCampo,strEtiquetaCampo,cintTipoCampoFecha,2)
    return false; 
  }
  
  if (valor.substr(3,2)> 12) {
    MostrarMensaje(objCampo,strEtiquetaCampo,cintTipoCampoFecha,1)
    return false; 
  }
  
  if ((valor.substr(6,4)> 2020) || (valor.substr(5,4)< 1920)) {
    MostrarMensaje(objCampo,strEtiquetaCampo,cintTipoCampoFecha,3)
    return false; 
  }
  
  var fecha = new Date(valor.substr(6,4), valor.substr(3,2)-1, valor.substr(0,2));
  mesfecha=fecha.getMonth()+1;
  diafecha=fecha.getDate();
  mes=valor.substr(3,2);
  dia=valor.substr(0,2);
  
  if ((parseInt(mesfecha,10) !== parseInt(mes,10)) || ( parseInt(diafecha,10) !== parseInt(dia,10))) {
    MostrarMensaje(objCampo,strEtiquetaCampo,cintTipoCampoFecha,4)
    return false; 
  }

  return(true);
}

function fnAbreCierra() {
  if(blnMenuAbierto) {
    document.all.Frecuentes.style.visibility = "hidden";
    blnMenuAbierto = false;
  }
  else {
    document.all.Frecuentes.style.visibility = "visible";
     blnMenuAbierto = true;
  }
}

function strRedireccionaPOSAdmin(objNombrePagina) {
  var strURL = 'CCRedirectorPOSAdmin.aspx?strPageName=' + objNombrePagina;
  document.location.href = strURL;
}

// Parametros para entra al sitio de Consulta de Comisiones de empleados
function strURLComisionesSesion() {
  return "http://portalrrhh/comisiones/default.aspx?blnSessionDirecta=1&txtUsuario=sistemaADS&txtContrasena=sistemaADS"
}
function strURLComisionesSucursalConsulta() {
  return "http://portalrrhh/comisiones/reportes/listado_ComisionSucursal.aspx"          
}
function strURLComisionesFotolabConsulta() {
  return "http://portalrrhh/comisiones/reportes/listado_ComisionFotoLab.aspx"
}

// Parametros para entra al sitio de Consulta de Gastos de Sucursal
function strURLGastosSesion() {
   return "http://gastosweb/default.aspx?"
}
function strURLOnePageSesion() {
   return "http://gastos/default.aspx?"
}
function strURLGastosOperacionesConsulta() {
   return "http://gastosweb/reportes/FraRep_Operaciones.aspx"
}
function strURLGastosOnePageConsulta() {
   return "http://gastos/reportes/FraRep_OnePage.aspx"
}

// Parametros para entra al sitio de Consulta de Articulos de merma no Controlada

function strURLArtMermaSesion() {
   return "http://gastos/default.aspx?"
}
function strURLArtMermaConsulta() {
   return "http://gastos/reportes/FraRep_FiltrosArtMermaNoControlada.aspx"
}

function strUrlADSDoc() {
   // ../static/
   return "http://adsdoc/"
}


function PopHelp(url, width, height) {
  window.open(url, 'Pop', 'width=' + width + ',height=' + height + ',left=0,top=0,resizable=no,scrollbars=yes,menubar=no,status=no');
}

function PopFacturas(url, width, height) {
    window.open(url,'Pop','width=' + width + ',height=' + height + ',left=0,top=0,resizable=no,scrollbars=yes,menubar=no,status=no' );
}
function strGeneraTablaAyuda(objPagina) {
   var strTablaFactura;
   var strTablaAyuda;
   var strDivAyuda;
      
   strTablaFactura = '<table width="100%" border="0" cellspacing="0" cellpadding="0">';        
        
   strTablaFactura += '<tr>';
   strTablaFactura += '<td height="1" colspan="2" align="left" valign="top" bgcolor="#666666"><img src="../static/images/pixel.gif" width="1" height="1"></td>';
   strTablaFactura += '</tr>';
           
   strTablaFactura += '<tr>';
   strTablaFactura += '<td width="19%" height="25" align="center" valign="middle"><img src="../static/images/icono_imprimir.gif" width="19" height="15"></td>';
   strTablaFactura += '<td width="81%" height="25" align="left" valign="middle">';
   strTablaFactura += '<a href="javascript:PopFacturas(\'CCRedirectorPOSAdmin.aspx?strPageName=VentasFacturasImpresion.aspx\', 798, 525);" class="txayudablue01"><span class="txayudablue01"><strong>IMPRIMIR FACTURAS</strong></span></a>';        
   strTablaFactura += '</td>';
   strTablaFactura += '</tr>';
           
   strTablaFactura += '<tr>';
   strTablaFactura += '<td height="1" colspan="2" align="left" valign="top" bgcolor="#666666"><img src="../static/images/pixel.gif" width="1" height="1"></td>';
   strTablaFactura += '</tr>';
           
   strTablaFactura += '</table>';
           
   strTablaFactura += '<br>';
   document.write(strTablaFactura);        
   
}    

function crearTablaFirmaCompras() {
	    document.write("<br><br><br><br><br><table width=\"770px\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
        document.write("<tr>"); 
        document.write("<td width=\"02%\">&nbsp;</td>");
        document.write("<td width=\"20%\">___________________</td>");
        document.write("<td width=\"14%\">&nbsp;</td>");
        document.write("<td width=\"30%\">____________________________</td>");
        document.write("<td width=\"14%\">&nbsp;</td>");
        document.write("<td width=\"20%\">___________________</td>");
        document.write("</tr>");
        
        document.write("<tr>");    
        document.write("<td width=\"02%\">&nbsp;</td>");     
        document.write("<td class=\"tdtittablas\" align=\"center\">Nombre y Firma</td>");        
        document.write("<td>&nbsp;</td>");        
        document.write("<td class=\"tdtittablas\" align=\"center\">Nombre y Firma</td>");        
        document.write("<td>&nbsp;</td>");        
        document.write("<td class=\"tdtittablas\" align=\"center\">Nombre y Firma</td>");
        document.write("</tr>");
        
        document.write("<tr>"); 
        document.write("<td width=\"02%\">&nbsp;</td>");
        document.write("<td class=\"tdtittablas\" align=\"center\">Chofer Repartidor</td>");
        document.write("<td>&nbsp;</td>");
        document.write("<td class=\"tdtittablas\" align=\"center\">Capturó Documento</td>");
        document.write("<td>&nbsp;</td>");
        document.write("<td class=\"tdtittablas\" align=\"center\">Gte. Sucursal</td>");
        document.write("</tr>");
        
        document.write("<tr>");
        document.write("<td width=\"02%\">&nbsp;</td>");
        document.write("<td colspan=\"5\">&nbsp;</td>");
        document.write("</tr>");
        
        document.write("<tr>"); 
        document.write("<td width=\"02%\">&nbsp;</td>");
        document.write("<td class=\"tdtittablas\" colspan=\"5\"> * Este documento no será válido sin el nombre y firma de autorización del representante del proveedor.* </td>");
        document.write("</tr>");
        document.write("</table>");
}



