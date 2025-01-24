<template>
    <form @submit.prevent="searchRoute" class="space-y-4">
      <div>
        <label class="block text-gray-700 font-bold mb-2">Aeropuerto de Origen</label>
        <select 
          v-model="origin" 
          required 
          class="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500"
        >
            <option value="">Seleccione Origen</option>
            <option value="BGA">BGA - Bucaramanga</option>
            <option value="BTA">BTA - Bogotá</option>
            <option value="MED">MED - Medellín</option>
            <option value="CTG">CTG - Cartagena</option>
            <option value="CAL">CAL - Cali</option>
            <option value="ENV">ENV - Envigado</option>
            <option value="STA">STA - Santa Marta</option>
        </select>
      </div>
      
      <div>
        <label class="block text-gray-700 font-bold mb-2">Aeropuerto de Destino</label>
        <select 
          v-model="destination" 
          required 
          class="w-full px-3 py-2 border rounded-lg focus:ring-2 focus:ring-blue-500"
        >
            <option value="">Seleccione Destino</option>
            <option value="BGA">BGA - Bucaramanga</option>
            <option value="BTA">BTA - Bogotá</option>
            <option value="MED">MED - Medellín</option>
            <option value="CTG">CTG - Cartagena</option>
            <option value="CAL">CAL - Cali</option>
            <option value="ENV">ENV - Envigado</option>
            <option value="STA">STA - Santa Marta</option>
        </select>
      </div>
      
      <button 
        type="submit" 
        class="w-full bg-blue-600 text-white py-2 rounded-lg hover:bg-blue-700 transition"
      >
        Buscar Ruta
      </button>
    </form>
  </template>
  
  <script>
  export default {
    data() {
      return {
        origin: '',
        destination: ''
      }
    },
    methods: {
      searchRoute() {
        if (this.origin && this.destination) {
          this.$emit('find-route', this.origin, this.destination)
        }
      }
    }
  }
  </script>
  