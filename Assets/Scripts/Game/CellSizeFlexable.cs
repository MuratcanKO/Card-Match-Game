using UnityEngine;
using UnityEngine.UI;

public class CellSizeFlexable : MonoBehaviour
{
    public GridLayoutGroup gridLayoutGroup;
    public int maxCellCount = 12;

    private void Update()
    {
        int childCount = transform.childCount;
        int rowCount = Mathf.CeilToInt((float)childCount / gridLayoutGroup.constraintCount);

        float totalWidth = gridLayoutGroup.cellSize.x * gridLayoutGroup.constraintCount + (gridLayoutGroup.spacing.x * (gridLayoutGroup.constraintCount - 1));
        float totalHeight = gridLayoutGroup.cellSize.y * rowCount + (gridLayoutGroup.spacing.y * (rowCount - 1));

        if (childCount > maxCellCount)
        {
            int maxRowCount = Mathf.CeilToInt((float)maxCellCount / gridLayoutGroup.constraintCount);
            float newCellSizeX = gridLayoutGroup.cellSize.x / 3f * 2f;
            float newCellSizeY = gridLayoutGroup.cellSize.y / 3f * 2f;
            gridLayoutGroup.cellSize = new Vector2(newCellSizeX, newCellSizeY);
            maxCellCount *= 2;
        }
    }
}
