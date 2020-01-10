import MainComponent from "@/components/MainComponent";
import BrandCreateComponent from "@/components/BrandCreateComponent";
import BrandEditComponent from "@/components/BrandEditComponent";
import BrandMultipleComponent from "@/components/BrandMultipleComponent";
import BrandSingleComponent from "@/components/BrandSingleComponent";
import PerfumeCreateComponent from "@/components/PerfumeCreateComponent";
import PerfumeEditComponent from "@/components/PerfumeEditComponent";
import PerfumeMultipleComponent from "@/components/PerfumeMultipleComponent";
import PerfumeSingleComponent from "@/components/PerfumeSingleComponent";

const routes = [
    { path: '/', component: MainComponent, children:
        [
            { path: '', name: 'perfumes', component: PerfumeMultipleComponent},
            { path: 'perfumes/:id', name: 'perfume', component: PerfumeSingleComponent},
            { path: 'brands', name: 'brands', component: BrandMultipleComponent},
            { path: 'brands/:id', name: 'brand', component: BrandSingleComponent},
            { path: 'brand/create', name: 'brand.create', component: BrandCreateComponent},
            { path: 'brands/:id/edit', name: 'brand.edit', component: BrandEditComponent},
            { path: 'perfume/create', name: 'perfume.create', component: PerfumeCreateComponent},
            { path: 'perfumes/:id/edit', name: 'perfume.edit', component: PerfumeEditComponent},
        ]
    }
];

export default routes;