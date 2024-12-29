import { Component, createEffect, createSignal, For } from "solid-js";
import {
    Accordion,
    AccordionContent,
    AccordionItem,
    AccordionTrigger
  } from "~/components/ui/accordion"

  import ProductCard from './ProductCard';

const SubcategoryAccordion:Component<{subcategory:Subcategory}> = props => {
    let [backgroundColor, setBackgroundColor] = createSignal("#888888");
    createEffect(() => {
        let lowStock = false;

        props.subcategory.products.forEach(product => {
            if(product.currentStock <= product.minStock){
                lowStock = true
            }
        })
        
        if(lowStock){
            setBackgroundColor("#ff8a80")
        }
        else{
            setBackgroundColor("#c8e6c9");
        };
    })

    return (
        <Accordion multiple={false} collapsible style={{"background-color": backgroundColor()}}>
            <AccordionItem value="item-1">
                <AccordionTrigger> {props.subcategory.name} - {props.subcategory.products.length} products </AccordionTrigger>
                <AccordionContent>
                    {/* Product Cards */}
                    <For each ={props.subcategory.products}>
                    {product => 
                        <div>
                        <ProductCard product={product} />
                        </div>
                    }
                    </For>
                    {/* -------------------------------------------------------------------------------- */}
                </AccordionContent>
            </AccordionItem>
      </Accordion>
    )
}

export default SubcategoryAccordion