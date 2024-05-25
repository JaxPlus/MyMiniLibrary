<script setup lang="ts">
import Book from "../Models/Book.ts";
import {onMounted, ref} from "vue";

/** @todo PO NAJECHANIU MA WYŚWIETLAĆ SZCZEGÓŁY */
const props = defineProps<{
  book: Book
}>()

const className = ref("")

onMounted(() => {
  className.value = props.book.seriesName.toLowerCase().replace(/[$&+,:;=?@#|'<>.^*()%!-]/gm, '').replace(/ /gm, '-')
  
  addDynamicStyle(className.value)
})

function addDynamicStyle(className: string) {
  const style = document.createElement("style");
  style.textContent = `
    .${className}:hover {
      background: #323792;
    }
  `;
  document.head.append(style);
}
</script>

<template>
  <div :class="className">
    {{ book.name }}
  </div>
</template>

<style scoped>
div {
  margin: 5px;
  border: #535bf2 3px solid;
  border-radius: 5px;
  max-width: 32px;
  min-height: 10vh;
}
</style>