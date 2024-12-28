import { createEffect, createResource, For, type Component } from 'solid-js';

import {
  Accordion,
  AccordionContent,
  AccordionItem,
  AccordionTrigger
} from "~/components/ui/accordion"

import CardComponent from './CardComponent';

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
            <Accordion multiple={false} collapsible>
              <AccordionItem value="item-1">
                <AccordionTrigger> {category.name} - {category.subcategories.length} subcategories </AccordionTrigger>
                <AccordionContent>                  
                  {/* Subcategory Accordion */}
                  <For each ={category.subcategories}>
                    {subcategory =>
                      <div>
                        <Accordion multiple={false} collapsible>
                          <AccordionItem value="item-1">
                            <AccordionTrigger> {subcategory.name} - {subcategory.products.length} products </AccordionTrigger>
                            <AccordionContent>
                              {/* Product Cards */}
                              <For each ={subcategory.products}>
                                {product => 
                                  <div>
                                    <CardComponent product={product} />
                                  </div>
                                }
                              </For>
                              {/* -------------------------------------------------------------------------------- */}
                            </AccordionContent>
                          </AccordionItem>
                        </Accordion>
                      </div>
                    }
                  </For>
                  {/* -------------------------------------------------------------------------------- */}
                </AccordionContent>
              </AccordionItem>
            </Accordion>
          </div>
          }
        </For>
      </div>
      {/* -------------------------------------------------------------------------------- */}
    </div>
  );
};

export default App;
