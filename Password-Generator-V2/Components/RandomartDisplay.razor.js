import { generateArt } from "/js/bm-randomart/bm-randomart.js" 

export function startGenerateArt(id, seed) {
    const canvas = document.getElementById("art-" + id);

    if (seed.length < 8) {
        const ctx = canvas.getContext('2d');
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        return;
    }

    generateArt(seed + "aaaaaaaaaaaaaaaaaaa", canvas);
}