<script setup lang="ts">
import Book from "../Models/Book.ts";
import { onMounted, ref } from "vue";

/** @todo PO NAJECHANIU MA WYŚWIETLAĆ SZCZEGÓŁY */
const props = defineProps<{
  book: Book
}>();

const bookDescShow = ref(false);
const className = ref("");

onMounted(() => {
  className.value = "book";
})
</script>

<template>
  <div @click="bookDescShow = true" :class="className">
    {{ book.name }}
  </div>
  
  <div v-if="bookDescShow" class="book-desc-container">
    <button @click="bookDescShow = false">
      <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 24 24"><path fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 12L6 6m6 6l6 6m-6-6l6-6m-6 6l-6 6"/></svg>
    </button>
    <div class="book-desc">
      <h2>{{ book.name }}</h2>
      <p>Seria: {{ book.seriesName }}</p>
      <p>Cena: {{ book.price }}zł</p>
      <p>Autor: {{ book.authorName }}</p>
      <p>Wydawca: {{ book.publishingHouseName }}</p>
    </div>
  </div>
</template>

<style scoped>
.book-desc {
}

.book-desc-container {
  position: fixed;
  top: 0;
  left: 0;
  height: 100%;
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  background: rgba(23, 23, 23, 0.8);
}

img {
  stroke: white;
}

.book {
  margin: 5px;
  border: #535bf2 3px solid;
  border-radius: 5px;
  max-width: 32px;
  min-height: 10vh;
  min-width: 28px;
  overflow: clip;
  padding: 2px;
}

.book:hover {
  background: #323792;
}
</style>