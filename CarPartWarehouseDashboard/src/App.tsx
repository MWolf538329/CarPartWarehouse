import { createEffect, createResource, For, Show, type Component } from 'solid-js';

import logo from './logo.svg';
import styles from './App.module.css';
import { Flex } from './components/ui/flex';
import { Switch, SwitchControl, SwitchLabel, SwitchThumb } from './components/ui/switch';
import { TextField, TextFieldInput, TextFieldLabel } from './components/ui/text-field';
import Navbar from './Navbar';

import {
  Accordion,
  AccordionContent,
  AccordionItem,
  AccordionTrigger
} from "~/components/ui/accordion"

import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle
} from "~/components/ui/card"
import CardComponent from './CardComponent';

const App: Component = () => {
  const [categories] = createResource<Category[] | undefined>(() => fetch("https://api.localhost/categories/subcategories/products").then(body=>body.json()))
  createEffect(() => console.log(categories()))


  return (
    <div>
      {/* Category Accordion */}
      <div>
        <For each ={categories()}>
          {category => 
          <div>
            <Accordion multiple={false} collapsible>
              <AccordionItem value="item-1">
                <AccordionTrigger> {category.name} </AccordionTrigger>
                <AccordionContent>
                  Yes. Display Subcategories!
                  
                  {/* Subcategory Accordion */}
                  <For each ={category.subcategories}>
                    {subcategory =>
                      <div>
                        <Accordion multiple={false} collapsible>
                          <AccordionItem value="item-1">
                            <AccordionTrigger> {subcategory.name} </AccordionTrigger>
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
