<template>
    <div v-if="loading" class="text-center mt-4">
      <div class="animate-spin inline-block w-8 h-8 border-4 border-blue-500 rounded-full"></div>
      <p>Buscando rutas...</p>
    </div>
  
    <div v-else-if="routeData" class="mt-4 bg-blue-50 p-4 rounded-lg">
      <h2 class="text-2xl font-bold text-blue-800 mb-4">Detalles de Ruta</h2>
      
      <div class="space-y-3">
        <div class="flex justify-between">
          <span>Origen:</span>
          <span>{{ routeData.origin }}</span>
        </div>
        
        <div class="flex justify-between">
          <span>Destino:</span>
          <span>{{ routeData.destination }}</span>
        </div>
        
        <div class="flex justify-between text-green-600 font-bold">
          <span>Precio Total:</span>
          <span>{{ routeData.price.toFixed(2) }} USD</span>
        </div>
      </div>
      
      <div v-if="routeData.flights && routeData.flights.length" class="mt-4">
        <h3 class="text-xl font-semibold text-blue-700 mb-2">Vuelos de Ida</h3>
        <div 
          v-for="(flight, index) in routeData.flights" 
          :key="`flight-ida-${index}`" 
          class="bg-white p-3 rounded-lg shadow-sm mb-2"
        >
          <div class="flex justify-between">
            <span>{{ flight.departureStation }} → {{ flight.arrivalStation }}</span>
            <span class="text-gray-600">
              {{ flight.transport ? `${flight.transport.flightCarrier} ${flight.transport.flightNumber}` : 'Sin información de transporte' }}
            </span>
          </div>
          <div class="text-right text-green-600 font-semibold">
            {{ flight.price.toFixed(2) }} USD
          </div>
        </div>
      </div>
  
      <div v-if="routeData.returnFlights && routeData.returnFlights.length" class="mt-6">
        <h3 class="text-xl font-semibold text-blue-700 mb-2">Vuelos de Retorno</h3>
        <div 
          v-for="(returnFlight, index) in routeData.returnFlights" 
          :key="`flight-retorno-${index}`" 
          class="bg-white p-3 rounded-lg shadow-sm mb-2"
        >
          <div class="flex justify-between">
            <span>{{ returnFlight.departureStation }} → {{ returnFlight.arrivalStation }}</span>
            <span class="text-gray-600">
              {{ returnFlight.transport ? `${returnFlight.transport.flightCarrier} ${returnFlight.transport.flightNumber}` : 'Sin información de transporte' }}
            </span>
          </div>
          <div class="text-right text-green-600 font-semibold">
            {{ returnFlight.price.toFixed(2) }} USD
          </div>
        </div>
      </div>
    </div>
  
    <div v-else class="mt-4 text-center text-red-600">
      No se encontraron rutas disponibles entre los aeropuertos seleccionados.
    </div>
  </template>
  
  <script>
  export default {
    props: {
      routeData: Object,
      loading: Boolean
    }
  };
  </script>
  