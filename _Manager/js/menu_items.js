var MENU_ITEMS = [
	['INICIO', 'InicioHome.aspx'],
	['VENTAS', 'VentasHome.aspx', null,	    
		['Cierres', 'VentasCierres.aspx', null, 
			['Consultar cortes en cero', 'VentasConsultarCortesEnCero.aspx'],
		],
		['Tickets', 'VentasTickets.aspx', null, 
			['Administrar políticas de tickets', 'VentasAdministrarPoliticasDeTickets.aspx'],
		],
		['Operaciones DEX', 'VentasOperacionesDEX.aspx'],
		['Recolecciones', 'VentasRecolecciones.aspx'],
		['Entrega de valores', 'VentasEntregaValores.aspx',null,
			['Consultas','VentasMontoMaximoFaltanteCaja.aspx'],
		],
		['Control de Pagares', '',null,
			['Alta de Sucursales', 'SucursalControlDePagaresCargaArchivo.aspx'],
			['Alta de Solicitud','SucursalControlDePagaresAlta.aspx'],
			['Consulta','SucursalControlDePagaresConsulta.aspx'],
		],
		['Productos de venta cruzada', 'VentasProductosComplementarios.aspx',null,
			['Consultar productos', 'VentasProductosComplementariosConsultar.aspx'],
			['Agregar productos individualmente','VentasProductosComplementariosAgregar.aspx?strOrigen=Menu'],
			['Agregar productos por archivo','VentasProductosComplementariosCargaArchivo.aspx'],
		],
		['Ventas en cuotas','VentasVentasEnCuotas.aspx',null,
					['Consultar promociones de ventas en cuotas','VentasVentasEnCuotasConsultar.aspx'],
					['Agregar promociones de venta en cuotas','VentasVentasEnCuotasAgregar.aspx'],
		],
		['Promociones Monedero', 'VentasPromocionesMonedero.aspx',null,
			['Administración', 'VentasPromocionesMonederoAdministrar.aspx'],
			['Reportes','#'],
		],
		['Ventas Facturación','VentasFacturacion.aspx',null,
					['Facturación global','VentasFacturacionGlobal.aspx'],
					['Facturación global CFDI','VentasFacturacionGlobalDiaria.aspx'],
					['Reporte Facturación Sucursal','VentasFacturacionReporteSucursal.aspx'],
		],		
		['Interfases SAP','VentasInterfaseSAP1.aspx',null,
					['Interfase Sap Venta Agregada','VentasInterfaseVentaAgregada.aspx'],
					['Interfase Sap Traslado de Stock','VentasInterfaseSapTrasladoStock.aspx'],
		],
		['CAPRES','' , null,
		            ['Sucursales Rematadoras', 'VentasCapreDescuentoRematadora.aspx'],
		            ['CAPRES por Categoría', 'VentasCapreDescuentoCategoria.aspx'],
		            ['CAPRES por Producto', 'VentasCapreDescuentoProducto.aspx'],
	        ],		
	],	
	['SUCURSAL', 'SucursalHome.aspx', null,	 
		['Direccion Fiscal', 'SucursalAdministrarDireccionFiscal.aspx', null],		
		['Asignación de cuotas', 'SucursalAsignacionDeCuotas.aspx', null,
			['Administrar cuotas de venta','SucursalAdministrarCuotasDeVenta.aspx'],
			['Administrar márgenes de compra', 'SucursalAdministrarMargenesDeCompra.aspx'],
		],		 
		['Mercancías', 'SucursalMercancias.aspx', null,
			['Consultar brincos en folios contables', 'SucursalConsultarBrincosContables.aspx'
			],
			['Administrar folios de mercancías', 'SucursalAdministrarFoliosDeMercancias.aspx'
			],	
			['Proveedores', 'SucursalMercanciasProveedores.aspx', {'bw' : 170},
			   ['Administrar Proveedores', 'SucursalProveedoresConsultar.aspx'],
			   ['Administrar Relación Sucursal','SucursalProveedoresConsultarSucursales.aspx'],				  
			   ['Alta proveedores a nueva sucursal', 'SucursalProveedoresAltaNuevaSucursal.aspx'],
			],
			['Devoluciones Articulos Autorizados', 'SucursalAdministrarDevolucionArticuloAutorizado.aspx'
			],
		],
		['Cuentas', 'SucursalCuentas.aspx', null,
			['Asignar cuentas a sucursales', 'SucursalAsignacionCuentasSucursal.aspx'
			],
		],
		['Puntos de venta', 'SucursalPuntosDeVenta.aspx', null,
			['Consultar cajas en sucursales', 'SucursalConsultarCajasEnSucursales.aspx'
			],
			['Consultar cajas inhabilitadas', 'SucursalConsultarCajasInhabilitadas.aspx'
			],	
			['Administrar políticas de POS', 'SucursalAdministrarPoliticasDePos.aspx'
			],
			['Administrar formato de datos políticas POS', 'SucursalAdministrarFormatoDatoPoliticaPos.aspx'
			],
			['Administrar estados operativos', 'SucursalAdministrarEstadoOperativoCaja.aspx'
			],
		],
		['Inventario Rotativo ', 'SucursalInventarioRotativoHome.aspx', null,
			['Listados Rotativos', 'SucursalInventarioRotativoListados.aspx', null,
				['Capturar Listado para Inventarios', 'ListadoParaInventariosRotativos.aspx'],
				['Importar datos', 'ImportarDatosParaInventariosRotativos.aspx'],
			],
			['Sucursales', 'SucursalInventarioRotativoSucursales.aspx', null,
				['Consultar sucusales sin cierre de inventario', 'SucursalSinCierreInventario.aspx'],
				['Deshabilitar sucursales', 'SucursalHabilitarInventarioRotativo.aspx'],
			],			
		],       
		['Encuestas', 'SucursalEncuestasHome.aspx', {'bw' : 122},
			['Respuestas', 'SucursalEncuestaAdministrarRespuestas.aspx',{'bw' : 140,'bl' : 120}],			
			['Preguntas',  'SucursalEncuestaAdministrarPreguntas.aspx', {'bw' : 140,'bl' : 120}],	
			['Encuestas',  'SucursalEncuestaAdministrarEncuestas.aspx', {'bw' : 140,'bl' : 120}],
			['Reportes',   'SucursalEncuestaReporteSucursales.aspx',{'bw' : 140,'bl' : 120}],
		],
		['Consulta de Fondo Fijo', 'SucursalFondoFijo.aspx'],
		['Fondo Fijo Servicios', 'SucursalFondoFijoServicio.aspx'],
		['Empresas de Servicios', 'SucursalEmpresasServiciosHome.aspx', {'bw' : 122},
			['Administrar Empresas', 'SucursalEmpresasServiciosAdministrarEmpresas.aspx',{'bw' : 140,'bl' : 120}],			
			['Consultar Pagos',  'SucursalEmpresasServiciosConsultarPagos.aspx', {'bw' : 140,'bl' : 120}],
		],
		['Corresponsalía', 'SucursalCorresponsaliaServicios.aspx', {'bw' : 122}, 
                ['Configurar Tickets', 'SucursalCorresponsaliaConfigurarTickets.aspx',{'bw' : 140,'bl' : 120}],
                ['Configurar Montos',  'SucursalCorresponsaliaConfigurarMontos.aspx', {'bw' : 140,'bl' : 120}],
        ],
        ['Señalización', 'SucursalSenalizacion.aspx', null, 
                ['Admnistración marca propia', 'SucursalSenalizacionAdministracionMarcaPropia.aspx'],
                ['Admnistración marca propia archivo',  'SucursalSenalizacionAdministracionMarcaPropiaArchivo.aspx'],
                ['Admnistración de promociones',  'SucursalSenalizacionBusquedaPromocionesTexto.aspx'],
        ],
        ['Servicios Virtuales', 'SucursalTipoServicioVirtual.aspx'],
        ['Avisos ABF', 'SucursalAvisosABF.aspx'],
        ['Promoción de Servicios', 'SucursalAsignacionDeArticuloHome.aspx', null,
		        ['Empresas de Servicios', 'SucursalAsignacionDeArticuloEmpresasServicios.aspx'],
			    ['Servicios Virtuales', 'SucursalAsignacionDeArticuloTipoServiciosVirtuales.aspx'],
				['Operaciones DEX', 'SucursalAsignacionDeArticuloDineroExpress.aspx'],
			    ['Tarjetas de Regalo', 'SucursalAsignacionDeArticuloTarjetaRegalo.aspx'],
		],
        ['Exhibiciones Adicionales', null, null, 
                ['Alta', 'RentaEspaciosCrear.aspx'],
                ['Consulta', 'RentaEspaciosConsulta.aspx'],                
        ],	
                ['Control de Asistencias', null, null, 
                   ['Administración Usuarios', 'ControlAsistenciaAdministracionDeUsuarios.aspx'],
                   ['Consulta', 'ControlAsistencia.aspx'],
                   ['Generar Archivo Adam', 'ControlAsistenciaArchivoAdam.aspx'],
                   ['Reporte Administrativo', 'ControlAsistenciaReporte.aspx'],
                   ['Reporte Coordinadores', 'ControlAsistenciaReportePorCoordinador.aspx'],
                   ['Administrar Observaciones', 'SistemaControlAsistenciaObservaciones.aspx'],
                   ['Administrar Periodo de Pago Sucursal', 'ControlAdministrarPeriodoPagoSucursal.aspx'],
                   ['Administrar Interfaces Adam', 'ControlAsistenciaAdministrarInterfasesAdam.aspx'],
           	],
                ['Visitas a Sucursales', 'SucursalReporteDeVisitasCentral.aspx'],
                ['Rutas para Transporte', null, null,
                    ['Administrar Rutas para Transporte', 'SucursalAdministrarRutaTransporte.aspx'],
                    ['Reporte Rutas para Transporte', 'SucursalAdministrarRutaTransporteReporte.aspx']
                ]                
	], 
	['SISTEMA', 'Sistema.aspx', null,
	        ['Administracion', null, {'bw' : 120},	
		       ['Proyectos de Sistemas', '', {'bw' : 220,'bl' : 118},
                          ['Actividades Administración', 'RegistroActividadesDesarrolloAdministracion.aspx'],                       
                          ['Actividades Asignación por Jefetura', 'RegistroActividadesDesarrolloAsignacionAdmin.aspx'],
                          ['Actividades Asignación por el Recurso','RegistroActividadesDesarrolloAsignacion.aspx'],
	                  ['Actividades Seguimiento', 'RegistroActividadesDesarrolloReporte.aspx'], ],
                ],
		['Transmisiones', 'SistemaTransmisiones.aspx', null,
			['Consultar nivel de servicio en transmisiones', 'SistemaConsultarNivelDeServicioEnTransmisiones.aspx'],
			['Consultar transmisiones pendientes', 'SistemaConsultarTransmisionesPendientes.aspx'],
			['Consultar actualizaciones pendientes', 'SistemaConsultarActualizacionesPendientes.aspx'],			
			['Enviar Catalogos a Sucursal', 'SistemaActualizarSucursal.aspx'],
		],
		['Tiendas', 'SistemaTiendas.aspx', null,
			['Administrar tiendas', 'SistemaAdministrarTiendas.aspx'],
		],
		['Usuarios', 'SistemaUsuarios.aspx', null,
			['Administrar grupos', 'SistemaAdministrarGrupos.aspx'],
			['Administrar usuarios','SistemaAdministrarUsuarios.aspx'],
		],
		['Monedas', 'SistemaMonedas.aspx', null,
			['Administrar monedas','SistemaAdministrarMonedas.aspx'],
			['Asignar monedas a sucursal', 'SistemaAsignarMonedas.aspx'],
			['Asignar tipo de cambio', '',{'bw' : 200},
			    ['Por Selección de Sucursales', 'SistemaAsignarTipoDeCambio.aspx'],
			    ['Por Ubicación de Sucursal',  'SistemaAsignarTipoDeCambioUbicacion.aspx'], ],
		],
		['Cuentas', 'SistemaCuentas.aspx', null,
			['Administrar cuentas', null],
			['Administrar días inhabiles','SistemaAdministrarDiasInhabiles.aspx'],
			['Administrar ubicaciones bancarias','SistemaAdministrarUbicacionesBancarias.aspx'],
		],
		['Clientes especiales', 'SistemaClientesEspeciales.aspx', null,
                        ['Administrar Clientes Institucionales','SistemaControlCteABFACtivaBloquea.aspx'],
			['Asignar artículos exceptos de descuento','VentasAdministrarArticulosExceptosDeDescuento.aspx'],
			['Asignar artículos con precio fijo','SistemaAsignarArticulosPrecioFijo.aspx'],
			['Asignar artículos no autorizados para venta a crédito', 'VentasAdministrarArticulosNoAutorizados.aspx'],
			['Asignar descuentos por cliente', 'VentasAdministrarDescuentosPorCliente.aspx'],
			['Asignar descuentos por división categoría', 'VentasAdministrarDescuentosPorDepartamento.aspx'],
            ['Recetas', 'SistemaRecetas.aspx', {'bw' : 200},
				['Revisar recetas', 'SistemaRevisarRecetas.aspx'],
				['Revisar Autorizacion Recetas', 'SistemaRevisarAutorizacionRecetas.aspx'],
			],
			['Administrar clientes', 'SistemaAdministrarClientesNuevos.aspx'],
			['Administrar tipos de recetas','SistemaAdministrarTiposDeRecetas.aspx'],
			['Administrar atributos','SistemaAdministrarAtributos.aspx'],
			['Administrar tipos de atributos','SistemaAdministrarTiposAtributos.aspx'],
		],
		['Empresas recolectoras', 'SistemaEmpresasRecolectoras.aspx', null,
			['Administrar empresas recolectoras','SistemaEmpresasRecolectorasAdministrarEmpresasRecolectoras.aspx'],
			['Asignar recolectoras a sucursales','SistemaEmpresasRecolectorasAsignarRecolectoras.aspx'],
		],
		['Comisiones DEX', 'SistemaComisionesDEX.aspx'],
		['BINes','SistemaBines.aspx',null,
			['Consultar BINes','SistemaBinesConsultar.aspx'],
			['Administrar BINes generales','SistemaBinesAdministrarGenerales.aspx'],
			['Administrar BINes para venta en cuotas','SistemaBinesAdministrarBinesPagoEnCuotas.aspx'],
			['Administrar Articulo Restringido', 'SistemaBinesAdministrarArticuloRestringido.aspx'],
		],
		['Consulta Promociones', '', null,
			['Consulta','SistemaConsultarPromociones.aspx'],
			['Consulta Masiva','SistemaConsultarPromocionesMasiva.aspx'],
		],		
	],
];

