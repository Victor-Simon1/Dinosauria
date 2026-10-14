import pandas as pd
import os
import json

#url = "https://paleobiodb.org/data1.2/occs/list.csv?base_name=Dinosauria&show=phylum,class,order,family,genus,species,loc,paleoloc,coords,strat"
#url2 = "https://paleobiodb.org/data1.2/taxa/list.csv?base_name=Dinosauria&show=class,order,suborder,infraorder,superfamily,family,subfamily,tribe,genus,species,loc,paleoloc,coords,strat"
TAXON ="https://paleobiodb.org/data1.2/taxa/list.csv?base_name=Dinosauria&show=attr,parent"

url = "https://paleobiodb.org/data1.2/taxa/list.csv?base_name=Dinosauria&show=attr,parent"

df = pd.read_csv("Dino.csv", sep=",", engine="python")
# construire dictionnaire des taxons
taxa = {}

for _, row in df.iterrows():
    taxa[row["orig_no"]] = {
        "name": row["taxon_name"],
        "rank": row["accepted_rank"],
        "is_synonym": row["difference"] == "subjective synonym of",
        "is_nomen_dubium":row["difference"] == "nomen dubium, species not entered",
        "parent": row["parent_no"],
        "real_name":row["accepted_name"]
    }

# cache pour accélérer
path_cache = {}

def build_path(taxon_no):

    if taxon_no in path_cache:
        return path_cache[taxon_no]

    path = []
    current = taxon_no

    while current in taxa:

        taxon = taxa[current]
        path.append(taxon["name"])

        parent = taxon["parent"]

        if pd.isna(parent):
            break

        current = parent

    path.reverse()

    # s'assurer que Dinosauria est racine
    if path[0] != "Dinosauria":
        path.insert(0, "Dinosauria")

    path_cache[taxon_no] = path

    return path


# dossier racine
base_dir = "Data/dinosaur_tree"
os.makedirs(base_dir, exist_ok=True)

species_count = 0

for taxon_no, taxon in taxa.items():

    path = build_path(taxon_no)

    # créer tous les dossiers taxonomiques
    if taxon["is_synonym"] == False:
        folder = os.path.join(base_dir, *path)
        os.makedirs(folder, exist_ok=True)

    rank = str(taxon["rank"]).lower()
    '''rank in ["species", "subspecies"] and'''
    if not taxon["is_synonym"]:

        species_count += 1

        species = path[-1]

        file_path = os.path.join(base_dir, *path[:], f"{species}.json")
        synonym = df[(df["taxon_name"] != df["accepted_name"]) & (df["accepted_name"].str.contains(taxon["name"])) ]["taxon_name"]
        #if(taxon["name"] == "Tyrannosaurus rex"):
         #   print(synonym.tolist())
        data = {
            "name": species,
            #"classification_path": path,
            "rank": taxon["rank"],
            "synonym":synonym.tolist(),
            "is_nomen_dubium":taxon["is_nomen_dubium"],
            "size_m": None,
            "weight_kg": None,
            "begin_year":None,
            "end_year":None,
            "period": None
        }

        with open(file_path, "w", encoding="utf-8") as f:
            json.dump(data, f, indent=4, ensure_ascii=False)


print("Espèces traitées :", species_count)
print("Taxons total :", len(taxa))