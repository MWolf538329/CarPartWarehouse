import { Component, createEffect, createSignal, For } from "solid-js";
import {
    Accordion,
    AccordionContent,
    AccordionItem,
    AccordionTrigger
} from "~/components/ui/accordion"

import SubcategoryAccordion from './SubcategoryAccordion';

const CategoryAccordion: Component<{ category: Category }> = props => {
    const [lowStock, setLowStock] = createSignal(false);
    createEffect(() => {
        let isLowStock = false;

        props.category.subcategories.forEach(subcategory => {
            subcategory.products.forEach(product => {
                if (product.currentStock <= product.minStock) {
                    isLowStock = true
                }
            })
        })

        setLowStock(isLowStock)
    })

    return (
        <Accordion multiple={false} collapsible class={lowStock() ? "bg-red-300" : "bg-green-300"}>
            <AccordionItem value="item-1">
                <AccordionTrigger> {props.category.name} - {props.category.subcategories.length} subcategories </AccordionTrigger>
                <AccordionContent>
                    {/* Subcategory Accordion */}
                    <For each={props.category.subcategories}>
                        {subcategory =>
                            <div>
                                <SubcategoryAccordion subcategory={subcategory} />
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