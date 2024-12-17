namespace AdventOfCode2024._2_December;

public class PuzzleInput
{
    public static string[] Get()
    {
        const string puzzle = "1 4 5 8 11 12 9\n7 8 9 10 12 15 17 17\n17 20 23 25 27 31\n55 57 58 61 63 64 70\n39 42 45 43 44\n84 85 86 87 90 89 86\n33 34 35 36 35 37 38 38\n8 9 11 8 10 11 13 17\n34 35 37 39 38 40 45\n47 50 50 51 53 54\n54 55 58 58 59 56\n95 98 99 99 99\n53 54 54 57 61\n65 68 71 71 73 78\n19 20 23 27 28 30 33 36\n78 79 81 85 83\n24 25 27 29 30 32 36 36\n78 79 80 83 86 90 93 97\n30 31 35 38 40 42 49\n61 63 66 71 74 75\n77 80 82 83 89 87\n58 61 68 70 71 74 75 75\n20 23 24 25 28 35 36 40\n25 28 35 36 38 40 46\n47 46 49 52 55\n78 76 78 79 81 78\n14 13 15 17 19 21 21\n77 74 77 79 80 84\n91 89 91 93 94 99\n65 64 63 65 66 67 70\n49 48 51 53 56 54 52\n29 28 30 33 31 34 34\n70 69 71 70 74\n41 38 39 41 43 41 46\n88 85 88 90 90 92\n37 34 36 37 37 39 42 40\n57 55 58 61 61 61\n46 44 46 46 50\n78 75 77 78 79 79 82 89\n86 83 86 87 91 92 95\n17 14 16 17 21 18\n34 32 36 39 39\n60 59 62 66 68 70 73 77\n59 58 60 61 63 65 69 75\n41 40 42 45 46 49 55 58\n4 3 4 5 8 15 16 14\n5 4 10 11 11\n15 14 17 24 26 30\n59 56 59 60 67 69 70 77\n38 38 39 41 43\n78 78 81 84 85 88 85\n24 24 25 27 29 30 31 31\n51 51 54 55 56 58 61 65\n30 30 32 35 40\n84 84 85 82 83\n45 45 48 49 46 43\n60 60 59 60 61 62 62\n35 35 36 33 36 39 43\n47 47 44 45 52\n85 85 86 86 88 91 94\n55 55 55 57 56\n24 24 24 27 29 31 32 32\n47 47 50 52 52 54 55 59\n41 41 41 43 49\n7 7 10 12 16 19 20 23\n28 28 30 34 37 38 40 39\n72 72 74 77 80 84 86 86\n25 25 27 29 32 36 39 43\n15 15 18 22 28\n79 79 82 89 92 93\n55 55 60 61 59\n23 23 24 31 33 33\n58 58 64 65 69\n76 76 83 84 87 89 92 97\n50 54 55 57 59\n23 27 28 30 31 32 33 31\n8 12 14 17 20 20\n31 35 37 40 42 43 46 50\n51 55 57 58 63\n37 41 44 47 45 46\n23 27 28 31 29 32 29\n68 72 75 72 72\n39 43 45 47 44 45 47 51\n20 24 21 24 30\n74 78 79 80 80 81 82 83\n58 62 64 64 67 68 69 67\n17 21 23 23 26 26\n21 25 27 29 30 30 34\n86 90 92 92 98\n23 27 29 30 33 37 39 40\n33 37 38 42 44 43\n29 33 36 37 40 44 44\n21 25 27 28 32 35 39\n56 60 62 66 67 73\n69 73 80 82 83 85 87\n22 26 31 34 35 38 41 39\n40 44 50 52 52\n45 49 54 57 58 60 64\n41 45 46 49 51 58 63\n46 53 55 56 59 62\n10 16 18 20 21 22 21\n19 24 26 29 29\n28 34 36 39 42 44 48\n10 17 20 21 23 26 32\n79 86 88 87 88\n8 13 14 15 13 16 13\n18 25 26 28 31 32 29 29\n19 24 21 22 26\n41 48 50 47 53\n58 65 68 68 69 72 74 75\n84 90 90 93 95 93\n63 68 68 69 69\n77 84 84 86 89 93\n9 14 16 16 17 20 27\n17 22 25 29 32 35 37 40\n76 83 87 89 86\n30 37 39 41 42 46 46\n76 83 84 85 89 91 95\n76 82 86 87 88 89 96\n68 75 80 81 83 85 88\n1 7 10 11 16 15\n82 87 90 96 96\n70 75 77 82 85 89\n18 25 27 30 33 39 41 46\n23 20 18 17 14 11 8 9\n98 96 95 92 91 90 90\n78 77 76 74 73 69\n52 51 50 47 44 42 39 33\n82 80 82 79 78 77 74\n41 38 39 37 40\n35 32 34 32 32\n81 78 75 72 73 71 68 64\n64 63 62 61 60 61 55\n19 17 16 13 13 10\n23 22 20 20 21\n52 50 49 48 45 45 44 44\n19 16 15 12 10 10 6\n25 24 24 23 22 20 13\n95 92 91 89 87 86 82 79\n54 51 49 46 42 44\n73 71 69 67 63 61 61\n82 80 77 73 72 70 66\n23 20 17 13 12 11 6\n33 30 29 22 21\n18 16 9 8 6 5 7\n89 86 85 80 80\n54 52 47 46 45 41\n73 71 70 68 66 65 59 53\n57 58 57 54 51\n88 89 86 84 82 79 76 78\n42 45 42 41 39 38 38\n74 77 76 74 70\n21 23 22 19 14\n15 18 17 20 18 17 16 13\n49 50 52 51 48 50\n21 23 20 22 19 16 16\n61 62 60 61 59 58 54\n94 97 94 93 94 88\n91 94 94 91 90\n43 46 45 45 47\n33 35 35 33 33\n63 65 62 60 60 56\n27 29 28 27 25 22 22 16\n80 83 79 77 75 72\n66 68 67 63 62 61 64\n31 33 32 28 28\n73 76 72 71 68 65 61\n62 65 64 63 59 57 51\n24 26 23 22 21 19 12 11\n23 24 19 18 15 14 16\n87 90 84 81 78 77 77\n80 82 80 74 70\n37 39 36 30 24\n66 66 64 61 60 59\n9 9 8 7 4 2 5\n30 30 28 27 25 25\n59 59 56 54 52 48\n27 27 25 23 20 17 10\n41 41 44 42 41 38 37\n92 92 91 94 92 94\n53 53 52 51 50 52 51 51\n29 29 30 29 26 22\n48 48 47 44 41 44 37\n60 60 57 57 54\n25 25 22 19 19 16 19\n39 39 38 35 32 32 30 30\n92 92 90 90 88 86 82\n86 86 86 84 81 80 79 72\n95 95 92 89 85 84 81 80\n30 30 27 23 20 18 15 16\n96 96 94 91 88 85 81 81\n77 77 75 74 70 68 66 62\n46 46 43 42 41 37 30\n67 67 60 57 55 54 52 51\n35 35 33 26 27\n79 79 76 74 68 66 65 65\n67 67 66 59 55\n51 51 48 43 40 33\n32 28 27 25 24\n39 35 32 31 30 29 31\n49 45 43 40 39 39\n45 41 39 37 36 32\n46 42 41 38 37 34 31 24\n85 81 82 81 80\n20 16 18 17 15 14 12 15\n71 67 65 62 65 62 60 60\n87 83 84 81 77\n9 5 8 7 6 1\n54 50 49 49 47 46 44\n98 94 93 93 92 91 94\n94 90 87 85 85 83 83\n79 75 75 72 68\n88 84 81 80 80 75\n43 39 35 32 31 29\n40 36 32 29 28 25 22 25\n62 58 57 53 53\n71 67 66 63 61 57 55 51\n53 49 45 42 37\n36 32 29 26 24 21 14 13\n96 92 89 86 84 79 78 79\n45 41 39 37 31 28 28\n93 89 84 81 79 76 74 70\n60 56 55 52 47 44 41 36\n55 48 45 43 41 39 36\n39 32 31 29 28 30\n80 73 71 69 67 65 63 63\n22 17 16 15 12 10 6\n92 86 84 81 79 76 74 69\n29 23 22 21 19 21 19\n70 64 61 58 61 60 58 61\n33 26 23 20 22 20 17 17\n57 50 53 50 48 45 44 40\n61 56 59 57 51\n30 25 23 23 22\n59 53 53 51 48 51\n19 13 10 9 7 7 7\n53 46 45 42 39 39 35\n17 11 11 9 6 1\n73 67 65 64 60 57 56 53\n69 63 59 57 58\n34 27 25 22 21 17 17\n53 47 43 41 40 36\n51 45 44 42 41 37 34 29\n60 55 52 51 48 46 40 39\n21 15 12 10 5 8\n26 19 13 12 11 9 7 7\n63 56 54 49 45\n38 31 25 23 21 19 13\n70 63 63 61 60 57 54 56\n68 64 63 62 59 59 57\n98 94 91 91 88 85 83 79\n49 51 53 54 57 62 65 71\n53 57 63 64 67 71\n30 34 35 39 42 43 43\n69 76 79 79 82 83 87\n66 66 63 60 60 59 55\n21 28 31 34 33 34\n85 84 83 80 79 79 79\n62 62 62 59 56\n91 90 87 82 79 79\n61 60 59 55 52\n71 69 70 72 74 76 79 76\n95 93 92 88 85 84 83 83\n86 82 80 77 76 69\n25 29 31 33 34 34 35 39\n23 23 24 21 20 19 15\n71 75 75 78 79\n88 86 89 89 92\n35 35 37 40 38 38\n59 59 58 54 52 48\n43 38 35 32 30 24 22 21\n64 69 69 72 74\n67 68 67 64 63 59 62\n71 71 65 63 60 56\n53 56 57 55 57 59 60 58\n75 78 75 72 74 71 68 68\n80 79 82 85 82 86\n79 73 73 72 72\n70 70 69 63 61 54\n31 37 44 46 47 49 52 51\n70 69 70 73 72 69\n31 31 28 31 30 27 25 18\n28 22 20 19 16 12\n60 55 52 52 49 47 46 42\n39 35 32 32 31 28 31\n16 20 21 25 24\n8 7 8 10 11 10 11\n78 81 84 87 87 88\n82 83 80 78 74\n2 7 9 12 13 17 19 18\n45 47 50 53 56 59 59\n21 21 23 21 23\n14 16 11 10 5\n86 89 88 87 86 84 82 82\n50 46 45 38 34\n16 19 21 23 20 22\n57 57 60 63 66 66 65\n75 74 75 79 83\n86 83 84 82 79 78 80\n65 65 62 61 63 61 59 59\n73 76 80 81 83 85 89\n99 92 93 91 90 83\n41 45 48 51 54 55 61\n85 79 72 71 69 70\n20 17 18 20 23 30 31 31\n62 63 64 66 66 70\n70 73 77 78 85\n66 65 68 70 76 78 82\n35 39 41 44 41 42 44\n12 19 22 25 28 30 32 37\n80 77 76 75 73 72 65\n93 86 80 79 75\n58 54 48 46 43 41\n29 27 30 33 30 31 34 41\n31 32 33 35 37 37 36\n34 35 33 27 26 25 24\n81 83 85 86 88 90 92 90\n47 46 44 40 38 41\n37 37 37 36 33 26\n85 85 79 78 75 74 72 73\n30 30 27 21 21\n42 42 40 36 36\n21 21 23 27 30\n69 75 76 78 78 78\n89 87 85 82 82\n58 54 52 53 52 49 46 48\n98 96 95 93 96 92\n45 44 42 40 33 28\n8 8 11 10 9 11\n82 77 76 73 66 63 58\n33 35 35 32 29 28 26 27\n50 47 45 45 43 40 38 34\n66 68 65 62 65 67\n13 8 6 5 1 2\n10 10 13 16 18 20 22 22\n76 77 80 82 80 80\n28 24 21 24 22 16\n68 64 61 60 59 56 53 55\n26 27 26 27 30 33 35 40\n61 67 67 68 71 78\n34 41 42 45 48 52 54 54\n71 74 75 73 74 78\n62 62 61 60 57\n41 35 33 30 29 27 25 19\n41 42 45 46 47 51 48\n25 25 28 31 33 31 35\n58 62 68 71 74 76 79 82\n67 73 76 80 82 84 86\n40 40 37 36 38 36\n88 84 81 76 73 70 70\n35 31 30 29 25\n42 35 32 28 23\n24 28 25 28 31 29\n25 29 32 36 41\n5 10 13 15 20 24\n9 9 11 12 13 15 18 15\n50 46 43 41 40 36 34\n40 38 38 39 40 44\n24 24 27 28 30 34 36 40\n46 48 50 47 45 42 37\n99 95 92 90 91 89 85\n3 9 10 12 14 18\n39 33 31 32 33\n73 70 72 76 77 80 80\n18 16 19 22 24 30\n27 27 24 22 19 16 12 5\n29 22 19 16 13 10 4 4\n14 16 13 9 4\n68 64 62 61 59 57 55 52\n22 26 28 29 29\n70 74 74 75 77 80 80\n85 85 82 80 79 77 75 75\n32 36 39 38 40 43 48\n54 55 55 57 60 62 62\n68 68 71 71 74 76\n24 28 31 32 33\n85 82 83 85 88 90 94\n80 82 87 89 90 89\n64 61 59 57 52 51 47\n64 70 73 75 72\n40 44 46 51 50\n48 53 56 58 55 56 56\n94 92 89 88 85 87 81\n24 19 16 13 12 9 7 7\n1 2 4 4 9\n94 93 92 95 93 91 89\n74 68 68 65 62 59 52\n4 7 5 7 5\n27 23 20 16 16\n56 54 56 59 59\n65 65 65 67 68 70 72 72\n66 68 73 74 74\n62 62 64 66 68\n65 69 66 69 71 72 72\n83 90 89 90 94\n56 56 57 57 59 61 68\n93 90 86 85 82 77\n34 30 30 29 26 26\n34 39 43 45 47 54\n12 13 12 10 7 1\n59 63 65 64 68\n14 14 16 17 21\n6 3 4 11 12 19\n76 74 71 70 67 67 66 68\n50 56 58 60 63 67 71\n55 49 46 45 44 43 42 44\n78 73 70 68 65 63 59 56\n89 86 89 89 91 93 91\n65 66 68 69 76 79 81 82\n22 21 18 17 16 14 7 4\n20 20 23 24 29 31 31\n45 50 53 59 61 62 64 71\n61 61 60 57 54 53 55\n73 69 66 64 63 60 60\n60 60 57 56 55 55 57\n78 76 76 79 80 83 90\n4 4 5 7 13\n73 73 73 71 69 69\n50 45 44 40 37 33\n3 4 7 10 13 16 19 23\n86 83 79 76 72\n85 84 85 87 90 97 99\n17 16 19 22 23 27 28\n87 81 78 81 78 76 75 72\n22 26 28 30 32 36\n38 33 30 29 27\n54 56 53 51 47 44 41 38\n43 43 44 47 48 52 59\n95 92 93 94 95 97\n46 46 49 53 54 57 59 57\n34 36 36 34 34\n39 36 34 34 33\n62 58 56 55 57 57\n80 83 81 81 79 77 72\n34 38 44 47 48 50 53 59\n24 19 17 15 15 13\n13 17 18 22 23\n10 8 9 12 16 18 17\n22 18 17 17 10\n75 80 79 80 83 84 86 84\n59 55 54 53 49 45\n34 39 45 46 46\n26 22 21 20 13 10 8 9\n16 15 13 11 10 9 10\n11 13 10 6 4 4\n59 61 59 56 53 49 45\n57 59 58 51 48 48\n33 29 27 26 22 17\n85 87 86 80 81\n56 56 59 65 67 70 69\n86 84 87 93 96 98 96\n54 57 60 62 65\n52 54 55 58 59 61 63\n73 72 71 68 67\n45 47 50 51 53 54 56\n24 23 22 20 19\n73 70 69 68 66 64\n30 32 33 35 37 39 40\n7 9 10 13 14 17 18 20\n67 66 64 61 59\n31 28 26 25 24 22 20 18\n20 17 14 13 11\n18 21 23 26 29 32 35\n53 54 57 60 62\n68 71 72 74 77 78 81 84\n22 24 25 26 29 31 34\n15 18 20 21 24 26 29 32\n41 39 38 35 34 31\n63 65 68 70 72 74 75 76\n97 94 92 89 86 84 81 80\n71 72 74 77 80 81\n54 51 49 48 47 45 42\n68 67 66 65 62\n24 26 29 30 31 32 34\n25 26 29 32 35 36 37\n88 86 83 80 77 76 75 74\n62 60 57 54 52 50 49\n64 62 59 58 56\n54 55 57 60 63 66\n28 30 31 32 34\n63 62 60 57 56 54 51 49\n83 85 86 88 89 91 92\n1 4 5 7 10 13 15\n32 31 30 28 26 24 23 20\n84 86 88 90 92 94 95\n24 23 21 20 19 18\n92 91 88 85 84\n23 26 27 28 31 32 33 36\n36 38 39 40 43 45 47 49\n29 26 24 21 20 17\n12 10 9 7 4 3 2\n25 23 21 19 17 15 13 12\n38 37 35 32 31\n11 12 15 18 19\n99 96 95 93 90\n39 37 36 33 30\n35 37 39 40 43\n79 76 74 73 70 68\n40 37 34 33 30 28\n71 70 68 67 65 64 63 62\n95 92 91 89 86 83\n45 44 43 40 39 36\n29 26 25 23 22 21\n67 68 71 73 75 78 79 82\n95 92 89 88 86 85\n6 7 10 11 12 14\n46 45 43 41 38 36\n31 29 27 26 25 22\n47 50 53 55 57\n70 71 73 76 77\n13 16 17 19 22 25 26 28\n40 42 43 44 47 50 51 52\n40 41 42 45 47 50\n70 71 74 76 78\n65 68 71 73 76\n23 26 29 30 33\n48 51 53 56 57 58\n69 70 73 74 77 78 80 81\n28 30 32 35 36\n67 68 69 71 73 76\n93 90 87 85 82 80\n67 65 64 62 60\n38 35 33 31 30 27 24 23\n98 96 94 92 89 86\n14 11 9 8 7 4\n71 72 73 76 77 79 82 83\n80 79 78 75 73 72 69\n10 8 6 5 3\n85 84 82 79 76 74 73 72\n60 57 56 55 54\n67 66 64 61 58 57 55\n56 59 62 63 65 66 69 70\n49 52 55 56 57 58 59 61\n98 96 94 92 89 86 83 81\n62 64 65 68 69\n33 35 36 37 38 41 43\n76 79 81 84 86\n22 23 26 29 32 34 36\n38 36 33 31 28\n77 75 74 73 72 69 67\n49 52 55 56 57 60 62\n92 91 88 86 85 83 80\n60 58 57 56 53 51 48\n34 37 40 43 44 47 49\n19 18 17 15 12 11\n86 83 81 79 76 75\n63 61 60 59 56\n62 63 66 68 70 73 74 77\n53 56 58 60 63 64 65 67\n4 6 8 9 10\n73 76 78 80 81\n66 64 61 59 58 57 54\n82 80 79 77 75\n14 15 18 21 23\n10 11 14 17 19\n32 34 37 40 43\n67 68 71 74 76 78\n85 83 80 79 77 76 73\n24 21 19 17 15 14 11\n24 23 20 17 15 13 11\n55 58 59 60 63 65 66 68\n37 36 33 30 28\n56 53 52 49 47 46 43\n76 73 71 69 67 64 63\n86 83 82 81 79 76 74\n74 75 77 80 82 83 85 87\n65 68 70 71 72 75 77\n51 48 45 42 39\n45 43 41 39 37 34\n14 16 19 21 23 25\n39 41 44 45 48 50 53\n51 50 49 46 45 43 42 39\n34 31 28 26 25 23 22\n55 57 60 62 64 66 67\n66 64 63 61 59 56 53\n33 35 38 41 42 44 46\n38 36 33 32 31 30 27\n26 27 30 31 32 35\n24 25 26 29 32 33\n65 64 63 61 58\n22 25 27 30 32 35 37 38\n33 32 30 27 25\n71 74 75 76 77\n82 81 80 79 78 76 75 74\n49 48 46 44 43 41 39\n41 42 44 46 47\n81 83 86 89 92 93\n12 14 16 18 20 23\n89 86 84 82 79 76 75\n75 76 77 78 79 81\n79 77 74 73 70 68 65 62\n12 14 17 18 19 20\n6 7 9 10 13 16 19 22\n66 65 64 62 61\n61 60 57 56 54 51 48 47\n69 67 65 63 62 60 58\n23 21 19 18 17\n20 23 25 27 28\n29 28 27 24 23 21 18\n68 66 65 64 63 61\n64 61 58 55 52 50 47\n70 67 64 61 60 57\n37 35 32 31 28 27 25\n59 60 62 65 68 69 72 75\n46 44 43 42 41 38 35\n19 21 24 26 27 28 31\n27 28 29 31 34 36 37 39\n80 78 75 73 70 69 68 65\n36 33 31 29 28\n88 85 82 79 77 74\n9 12 15 18 19\n16 14 11 10 8 5 4 3\n97 95 94 92 91 89\n47 48 50 52 54 55 58 61\n44 47 48 49 50 51\n50 51 53 56 58\n53 54 55 57 60 63 66\n18 21 22 23 25 27\n93 90 87 84 82 80 79\n60 63 64 66 69 72 75 77\n94 92 90 87 85 84 81\n37 39 42 45 48\n63 66 69 70 71 72\n46 47 50 52 54 57 60\n2 4 7 10 12\n41 38 37 34 33 31\n18 21 23 25 28 31\n16 15 14 12 11 10 7 5\n30 32 34 37 40 42 45 46\n1 3 4 6 9 10\n87 84 83 81 80 77\n49 51 54 55 57 58 60 62\n19 18 16 14 11 9\n1 2 3 4 5 8\n68 70 72 73 74\n35 32 31 29 26 23 22 20\n51 53 56 59 62 63 65 67\n79 81 84 85 87 90 93\n51 54 55 56 57 58\n21 23 24 25 28 29\n35 34 31 29 28 27 26\n30 27 25 23 20 17 16 14\n30 28 26 24 22 21 20 17\n18 21 22 25 28 31 32 34\n81 78 77 75 74\n72 75 78 81 83\n84 85 88 89 92 94 95 96\n15 17 18 20 21 23\n80 78 76 74 73 70 68 65\n54 51 50 48 46 45\n85 84 83 80 79 78 77\n34 31 30 28 26 23\n69 72 75 76 77 78 81\n52 54 55 57 59\n82 79 76 73 71 68 65 62\n72 74 75 76 79 80\n12 9 7 6 4 3 2 1\n50 51 52 53 55 58 59 60\n20 22 25 28 29\n67 70 73 75 76\n22 25 26 29 30\n48 50 53 56 57 59 62 63\n70 71 72 75 77 80 82\n87 84 81 79 77\n93 92 90 89 87\n69 70 71 73 74 77\n11 14 17 19 21 24 25 28\n85 88 89 92 94\n61 64 65 68 69 71 72\n6 7 9 12 14\n49 52 53 54 57 58 59\n57 54 51 49 48 47 45\n66 63 61 58 57 54 53 52\n25 24 22 19 16 15 12 11\n43 41 40 37 34 33 32\n93 91 88 86 84 82 81 78\n40 43 46 47 49 50\n56 53 51 48 47\n42 45 48 50 52 55\n62 60 57 54 52 51\n51 48 45 44 43 42 40\n28 26 23 22 19 16 13 11\n67 64 62 61 58 57\n80 83 84 87 88 89\n51 52 55 57 60 63 66\n13 10 7 5 3\n68 71 73 76 79 81 82\n91 89 86 85 82 81 80\n31 29 28 27 24 22 21\n21 18 17 14 11 10 9 8\n72 75 78 80 83 85\n55 57 58 61 63 66 69\n50 48 47 46 45\n76 79 82 85 87 88\n49 48 46 44 42 40 39 38\n68 69 71 74 76\n22 21 19 16 13\n27 24 23 22 19 18\n19 18 16 14 13 12 11\n79 81 84 86 89\n4 6 7 8 9 10\n20 23 26 28 29 30\n84 87 88 90 92\n31 33 34 37 39 41 43\n31 28 27 25 23 20\n49 52 55 58 60 62 65\n75 77 78 81 83 84 85 86\n56 53 51 50 47 44 42 39\n26 29 30 33 35 36 37 40\n63 66 67 69 72 73 74\n6 7 10 11 13 14 16\n67 66 63 62 61 60 59 58\n60 61 63 64 66 68 70\n19 17 16 15 13 12 9 6\n88 85 82 79 77 76 74\n15 14 12 11 9\n3 4 5 8 10 12\n14 12 9 7 6 4\n40 37 36 34 33 31\n28 31 34 36 37 39 40\n30 32 33 35 36 37\n62 60 58 57 55 54 51\n60 58 55 52 50\n57 58 61 63 66 69 70 72\n81 80 77 76 75 73\n72 70 69 66 64 62 59\n84 81 78 77 75 74 73\n79 82 84 87 89 92\n84 87 88 90 92 94\n28 25 23 22 21\n57 56 53 52 51 50 48\n25 27 29 31 32 35 36\n20 22 25 27 28 31\n41 40 37 34 32 30 28\n52 55 58 59 60 62 65\n57 55 54 52 50 48 45\n81 78 75 74 71\n73 76 78 80 82\n26 25 22 20 19 16 15 13\n68 67 65 62 60 58 56\n43 41 39 37 35\n70 73 74 77 79 80\n88 85 83 80 77 74 72\n82 79 76 73 70\n56 53 52 49 46 43 40\n45 42 40 39 38 35 32\n21 23 24 27 30 31 32 35\n28 30 31 32 33 34 35 37\n66 69 71 73 74 75\n56 57 60 61 64\n81 79 77 76 73 71\n81 79 78 75 72 70\n55 56 57 59 62 65 67\n55 52 50 48 45\n9 7 4 3 2 1\n27 28 31 33 35 36\n89 88 86 85 83 82 81 78\n4 7 10 11 12 14 16 19\n49 51 53 56 57 59 62\n30 29 26 23 21 18 16 15\n67 66 64 61 60\n62 61 59 56 55\n57 59 62 64 67\n71 72 75 77 78 79 81\n45 47 50 52 54 56\n21 23 26 28 30 33 36 38\n54 55 58 61 63 65 67 70\n50 49 48 47 45 43\n70 71 72 73 75 77\n22 24 27 30 32 33 36 37\n83 86 89 91 93 94 97\n32 31 29 27 24\n68 69 72 75 78 80\n64 65 66 67 70 73\n37 35 32 29 26\n39 37 34 33 30 27\n15 16 17 18 20\n75 73 72 70 69 68 65 63\n45 47 48 51 54 56\n29 28 27 25 22 19 18 15\n4 7 8 9 12 13 16 17\n62 65 66 69 70 72\n26 24 21 18 15 13 10 7\n2 5 6 9 12 13\n70 69 67 66 65 62\n37 40 42 45 48\n92 90 89 88 86 83 80 79\n72 70 69 66 63\n35 33 31 30 29 28\n56 58 60 61 63 65\n58 56 55 52 50\n35 32 29 28 27 24 21\n99 96 95 92 89\n15 16 19 21 22 23 25\n1 3 4 7 10 13 14 17\n89 88 87 85 84 82 81 78\n29 30 32 33 36 37\n73 75 78 79 80 82 84\n67 69 72 75 77\n45 42 41 38 37 35 34\n40 43 46 48 49\n54 56 58 59 60 63 64 66\n24 26 29 32 33\n95 93 90 87 84\n71 68 65 63 62 61\n53 51 50 48 47\n32 30 28 27 24 23\n46 49 52 53 55 57 58\n54 57 60 62 63 65 67\n12 13 14 17 20 22 25 28\n36 38 40 42 45 46 48\n84 85 86 87 89\n64 62 59 57 56 53 50 48\n54 57 59 62 65 66 69 70\n82 81 80 79 77 75\n21 22 24 26 27 30 33\n52 49 46 45 44 41\n47 49 51 52 54 56 59 60\n67 68 70 71 73 75\n13 15 17 19 21 22 23\n25 27 28 31 34 36 38 39\n23 20 17 16 13 10 9 8\n78 80 82 85 86 89 91 94\n82 85 87 89 90 93 94\n51 48 47 44 41 38 35\n17 20 23 25 27\n19 22 23 25 28 31 34\n76 74 73 71 68\n49 52 53 55 57 58 59 61\n52 54 56 59 62\n73 70 68 66 64 62 61 60\n92 89 88 87 85\n21 24 27 28 29\n23 20 19 16 14\n44 45 48 51 52\n44 41 39 38 35\n42 41 38 35 32 31\n17 18 19 20 21 23\n27 30 32 34 36 38 41 44\n9 11 12 13 16 17\n16 13 10 8 5 4 2\n52 53 56 58 59 60 61\n29 32 34 36 39 41 44\n77 78 81 84 87\n61 59 56 53 51 49 48 45\n52 53 55 56 58 60 63\n24 25 28 31 32 35 38 40\n20 22 25 27 30\n65 67 68 71 74 75\n45 48 50 51 53 54 56\n70 69 66 64 63 62\n30 29 27 26 24 22\n53 55 58 59 61 62\n31 29 27 26 24 22 20 18\n2 4 7 9 12 13\n39 38 37 35 34 31 29\n60 58 56 53 51 49 48\n4 7 8 10 12 14\n40 38 35 32 29 28 26 24\n90 88 86 83 82 79\n56 57 58 61 64 66 69 72\n80 82 83 85 87 89 90\n39 38 36 33 30 29\n33 30 29 27 24 22 21 18\n54 57 58 59 60 62\n81 84 86 87 90 92 93 96\n22 23 26 28 31\n70 68 67 66 63\n29 27 25 23 22 20\n25 27 28 31 32 35 38 39\n77 76 73 70 68 67\n61 59 58 57 56\n40 41 43 46 48\n31 28 26 23 22 21 20 17\n45 43 41 38 35\n46 48 49 51 54 55\n50 52 53 54 55 58 61 64\n16 13 11 10 9 7 4 1\n34 37 38 40 42\n97 95 94 93 90 89 88 87\n30 32 34 36 38 39 41 43\n73 70 67 66 64 63 62\n82 80 79 76 73 72\n53 50 47 45 44 41 40 39\n81 83 86 88 91 93 94\n24 22 20 17 16 15\n55 56 58 59 60 63 65 67\n9 12 14 17 18 19 22\n19 16 15 13 10 7 5\n97 95 94 92 91 89 88 87\n78 80 82 83 85 86 88 90\n45 48 51 52 53 54\n54 53 52 50 48 47 46 45\n55 54 53 52 50\n38 35 34 33 30 27 26\n65 62 61 59 58 55\n33 35 36 38 41 42 43 45\n35 32 29 28 27 26 23\n39 37 35 32 31 28 26 24\n2 3 4 6 7 10 12 15\n17 19 22 23 25 28\n53 55 58 60 63 65 68\n64 67 70 72 75\n78 75 72 70 68 67\n56 54 51 50 47 44\n21 18 15 12 11 9\n56 54 51 49 48 45 42 39\n50 47 44 42 41 39 37\n72 75 77 78 81 83 84\n85 84 83 82 79 76\n83 81 78 75 72\n80 82 84 87 90 93 95\n81 83 84 87 89 90\n68 71 72 74 77 78 79\n70 71 72 75 78 81 83 84\n20 19 16 15 13\n12 9 8 7 6 5 2\n22 23 25 26 28 29 31 32\n32 30 28 25 22 20\n35 32 31 28 25 23\n36 39 40 41 44 46 48 50\n52 55 56 59 62\n50 48 45 43 40 39 37 36\n36 35 33 32 31 28\n50 48 47 44 43 41 38 36\n6 5 4 2 1\n19 16 14 12 9 7 4\n28 30 32 33 35\n75 73 70 68 65\n25 23 20 18 17 14 12\n67 70 72 73 76 77 78\n73 75 76 79 82 83\n37 35 34 31 29\n99 97 95 93 91 89\n8 9 10 11 12 15\n60 59 56 55 52 49 48 47\n54 53 51 50 48 47\n32 35 37 39 40 42\n79 78 77 76 75\n43 42 40 37 34 31\n22 23 25 28 31\n98 96 93 92 89 88 85\n60 59 56 54 52 50 48 47\n71 72 73 74 77 78 81\n37 34 32 30 28 27\n18 21 22 23 24\n29 31 33 35 36 39 42 44\n36 33 30 29 26 23 21 18\n44 46 47 49 50 53 55 57\n69 66 65 62 59\n80 81 83 84 87\n62 65 68 71 74\n56 53 52 50 47\n36 39 42 43 45 47 49\n68 65 64 62 60 57 54\n78 75 73 71 69 67 65 63\n50 52 54 55 57 59 60\n73 72 71 70 69 67\n99 96 93 90 87\n34 32 31 28 27 24 22\n78 81 82 84 85 87 88\n37 35 34 33 30\n70 69 68 65 63 62\n85 82 80 77 75 74 72 69\n33 35 38 41 42\n67 64 62 60 58\n38 36 35 34 31 30\n64 67 69 71 74 77\n89 86 83 80 79 77\n80 77 75 74 71\n76 79 82 83 86\n92 89 86 85 84 82 79 77\n14 17 20 22 25 28\n23 26 27 29 32 35 36\n99 98 96 93 90 87 84\n41 43 44 47 49 52 53 56\n25 24 21 19 16 13 11\n46 49 52 54 56\n68 65 62 61 58\n73 70 68 65 62 61 60\n42 43 45 48 49\n61 64 67 70 72 74\n71 72 73 74 75 76\n89 86 84 81 79 76 73 72\n48 46 45 42 39 36 34 32\n66 63 61 59 56 55 53\n18 20 22 24 27 30 33\n50 49 47 46 44\n69 70 71 74 75 78 79\n18 16 13 12 11 8 7\n57 59 60 62 64 67\n25 27 29 32 35\n71 68 67 65 64 61 58\n21 22 24 26 29 32 34 37\n89 87 85 82 79 78 75\n91 89 87 85 82 81 78\n77 79 81 82 85 86\n59 61 62 65 67 68\n94 93 92 91 90 87 85 83\n50 52 53 54 56 57 58 61";
        return puzzle.Split("\n");
    }
}