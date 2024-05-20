<script setup lang="ts">

const books = fetch("http://localhost:5296/api/book", {
  method: "GET",
  mode: "cors",
  credentials: "include",
  headers: { 
    "Content-Type": "application/json"
  },
}).then((response) => response.json());
console.log(books)
</script>

<template>
  <div>
    
  </div>
</template>