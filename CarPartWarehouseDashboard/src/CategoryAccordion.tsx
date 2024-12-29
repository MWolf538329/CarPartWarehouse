import { Component, createEffect, createSignal, For } from "solid-js";
import {
    Accordion,
    AccordionContent,
    AccordionItem,
    AccordionTrigger
  } from "~/components/ui/accordion"

  import SubcategoryAccordion from './SubcategoryAccordion';

const CategoryAccordion:Component<{category:Category}> = props => {
    let [backgroundColor, setBackgroundColor] = createSignal("#888888");
    createEffect(() => {
        let lowStock = false;

        props.category.subcategories.forEach(subcategory => {
            subcategory.products.forEach(product => {
                if(product.currentStock <= product.minStock){
                    lowStock = true
                }
            })
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
                <AccordionTrigger> {props.category.name} - {props.category.subcategories.length} subcategories </AccordionTrigger>
                <AccordionContent>                  
                    {/* Subcategory Accordion */}
                    <For each ={props.category.subcategories}>
                    {subcategory =>
                        <div>
                        <SubcategoryAccordion subcategory={subcategory}/>
                        </div>
                    }
                    </For>
                    {/* -------------------------------------------------------------------------------- */}
                </AccordionContent>
            </AccordionItem>
        </Accordion>
    )
}

export default CategoryAccordion