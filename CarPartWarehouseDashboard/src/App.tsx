import { createSignal, createEffect, createResource, For, type Component } from 'solid-js';

import CategoryAccordion from './CategoryAccordion';

const App: Component = () => {
  const [categories] = createResource<Category[] | undefined>(() => fetch("https://api.localhost/categories/subcategories/products").then(body=>body.json()))
  //createEffect(() => console.log(categories()))

  return (
    <div>
      {/* Category Accordion */}
      <div>
        <For each ={categories()}>
          {category => 
          <div>
            <CategoryAccordion category={category}/>
          </div>
          }
        </For>
      </div>
      {/* -------------------------------------------------------------------------------- */}
    </div>
  );
};

export default App;
