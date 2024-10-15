using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Node : MonoBehaviour
{
    public int node_number;
    public List<Node> Connected_nodes = new List<Node>();
    public bool visited;
    public TMP_Text node_num_text;
    public GameManager gamemanager;
    public Button button;

    public RectTransform rectTransform;

    private int l;
    private Line[] lines;
    public Line linePrefab; 

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagerObject = GameObject.Find("GameManager");
        gamemanager = gameManagerObject.GetComponent<GameManager>();
        rectTransform = GetComponent<RectTransform>();

        button = GetComponent<Button>();
        
        visited = false;
        if (node_number != gamemanager.root)
        {
            this.gameObject.SetActive(false);
        }

        l = Connected_nodes.Count;

        lines = new Line[l];

        for (int i = 0; i < l; i++)
        {
            Line line = Instantiate(linePrefab);
            line.transform.SetParent(transform, false);
            lines[i] = line;
        }
    }

    public void OnClick()
    {
        visited = true;

        ColorBlock colorBlock = button.colors;
        colorBlock.normalColor = new Color((170f / 256f), (194f / 256f), (237f / 256f), 1f);
        colorBlock.selectedColor = new Color((170f / 256f), (194f / 256f), (237f / 256f), 1f);
        button.colors = colorBlock;

        foreach (Node node in Connected_nodes)
        {
            if (node.visited == false)
            {
                node.gameObject.SetActive(true);
            }
        }
        for (int i = 0; i < l; i++)
        {
            Node node = Connected_nodes[i];
            Line line = lines[i];
            if (node.visited == false)
            {
                node.gameObject.SetActive(true);
            }
            line.SetStart(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y);
            line.SetEnd(node.rectTransform.anchoredPosition.x, node.rectTransform.anchoredPosition.y);
            line.SetV();
            line.DrawLine();
        }
    }
}
